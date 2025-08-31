// ------------------------------------------------------------------------------
// This script handles the generation of JSON files that will be used in other
// scripts and '.astro' components.
// ------------------------------------------------------------------------------

// ------------------------------------------------------------------------------
// Imports
// ------------------------------------------------------------------------------
const kleur = require("kleur"); // Terminal highlighting
const fs = require('fs'); // Interact with the file system
const path = require('path'); // Handle and transform file paths

// ------------------------------------------------------------------------------
// Paths constants
// ------------------------------------------------------------------------------
const guidesDir = './src/content/docs/guides'; // Path to base directory containing the "Guides" groups
const beyondDir = './src/content/docs/guides/beyond-splashkit'; // Path to base directory containing the "Beyond SplashKit" groups

const guidesGrouptsOutputJson = './scripts/json-files/guides-groups.json'; // Path where the "Guides" groups output JSON files will be saved
const beyondSkGroupsOutputJson = './scripts/json-files/beyond-splashkit-groups.json'; // Path where the "Beyond SplashKit" groups output JSON files will be saved

const guidesJsonDir = './scripts/json-files/guides'; // Path where the "Guides" groups output JSON files will be saved
const guidesFunctionsJson = './scripts/json-files/guides.json'; // Path where the "Guides" functions output JSON files will be saved


// ------------------------------------------------------------------------------
// Read the contents of the guides directory 
// ------------------------------------------------------------------------------
function getDirNames(directory) {
    return fs.readdirSync(directory, { withFileTypes: true })
        // Filter out only the directories from the list of files and directories
        .filter(dirent => dirent.isDirectory())
        // Map the directory names to lowercase to standardise them
        .map(dirent => dirent.name);
}

// ------------------------------------------------------------------------------
// Generate json files with list of names of folders (used for the index pages)
// ------------------------------------------------------------------------------
function generateIndexPageCategories(folderGroupName, srcDirectory, outputDirectory) {
    try {
        const folderNames = getDirNames(srcDirectory);
        fs.writeFileSync(outputDirectory, JSON.stringify(folderNames, null, 2)); // Write the list of group names to the output JSON file
        console.log(kleur.yellow(`${folderGroupName}: `) + kleur.green("Available index page category names have been written to " + outputDirectory)); // Log a message to the console indicating that the JSON file has been created
    } catch (err) {
        console.log(kleur.red(`Error writing output files for ${folderGroupName}: `, err));
    }
}

// ------------------------------------------------------------------------------
// Read the json files in the "scripts/json-files/guides/*" directories
// ------------------------------------------------------------------------------
function getAvailableGuidesFunctionUsage(dir) {
    const result = {};

    const folders = fs.readdirSync(dir);
    folders.forEach(folder => {
        const folderPath = path.join(dir, folder);

        var jsonFiles;
        try {
            const stats = fs.statSync(folderPath);
            // Checking if the path is a directory
            if (stats.isDirectory()) {
                const files = fs.readdirSync(folderPath);
                // Filtering for JSON files
                jsonFiles = files.filter(file => path.extname(file).toLowerCase() === '.json');

                if (jsonFiles.length > 0) {
                    const fileName = `${folder.toLowerCase()}.json`;
                    try {
                        const jsonFile = fs.readFileSync(`${folderPath}/${fileName}`);
                        const jsonData = JSON.parse(jsonFile);

                        if (!result[folder.toLowerCase()]) {
                            result[folder.toLowerCase()] = [];
                        }

                        result[folder.toLowerCase()].push(...jsonData.guides);

                    } catch (error) {
                        console.error(`Error parsing JSON in file: ${jsonFiles}`);
                        console.error(error.message);
                    }
                }
            } else {
                if (folder != "README.md")
                console.log(`${folder} is not a diectory`);
            }
        } catch (err) {
            console.log(`Error loading JSON in folder: ${folder}`);
        }
    })
    return result;
}

// ------------------------------------------------------------------------------
// Generate json files with list of names of folders (used for the index pages)
// ------------------------------------------------------------------------------
function generateAvailableFunctionsInGuides(folderGroupName, srcDirectory, outputDirectory) {
    try {
        const guidesContent = getAvailableGuidesFunctionUsage(srcDirectory);

        try {
            fs.writeFileSync(outputDirectory, JSON.stringify(guidesContent, null, 4));
            console.log(kleur.yellow(`${folderGroupName}: `) + kleur.green(`Available functions written to ${outputDirectory}.\n`));
        } catch (err) {
            console.log(kleur.red('Error writing output files: ', err));
        }
    } catch (error) {
        console.log(kleur.red('Error processing guides files: ', error));
    }
}

// ==============================================================================
// ========================= START of main script ===============================
// ==============================================================================

console.log(kleur.cyan('------------------------------------------------------------------------------'));
console.log(kleur.magenta('JSON file Generation:'));
console.log(kleur.cyan('------------------------------------------------------------------------------\n'));

// ------------------------------------------------------------------------------
// Generate Index Page Categories
console.log("Generating json files for index page categories...");
generateIndexPageCategories("  Guides Groups", guidesDir, guidesGrouptsOutputJson); // For "Guides"
generateIndexPageCategories("  Beyond SplashKit Groups", beyondDir, beyondSkGroupsOutputJson); // For "Beyond SplashKit"


// ------------------------------------------------------------------------------
// Generate Available Guides Functions
console.log("\nGenerating json file for available functions used in guides...");
generateAvailableFunctionsInGuides("  Guides Functions", guidesJsonDir, guidesFunctionsJson);

console.log(kleur.green("All JSON files generated successfully.\n"));