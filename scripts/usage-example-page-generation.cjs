// Written and maintained by Olivia McKeon (@omckeon)

const fs = require("fs");
const kleur = require("kleur");
const path = require('path');

// For cleaning files from usage-examples folder
const directoryToClean = 'src/content/docs/usage-examples';
const filesToKeep = ['index.mdx', 'CONTRIBUTING.mdx'];

// Define language label mappings
const languageLabelMappings = {
  cpp: "C++",
  csharp: "C#",
  python: "Python",
  // pascal: "Pascal",
  // Add more mappings as needed
};

// Define language file extensions
const languageFileExtensions = {
  cpp: ".cpp",
  csharp: ".cs",
  python: ".py",
  pascal: ".pas"
};

const languageOrder = ["cpp", "csharp", "python"];//, "pascal"];

// Get JSON data from api.json file
function getJsonData() {
  var jsonFile;
  var jsonData;
  try {
    jsonFile = fs.readFileSync(`${__dirname}/api.json`);
  } catch (err) {
    console.error(kleur.red("Error reading JSON file:"), err);
    return;
  }
  try {
    jsonData = JSON.parse(jsonFile);
  } catch (error) {
    console.error(kleur.red("Error parsing JSON:"), error);
    return;
  }
  return jsonData;
}

// Get a list of the category groups from the json data
function getApiCategories(jsonData) {
  const apiCategories = [];
  for (const categoryKey in jsonData) {
    if (categoryKey != "types") {
      apiCategories.push(categoryKey);
    }
  }
  return apiCategories;
}

// Get a list of all of the unique function names
function getUniqueFunctionNames(categoryKey, jsonData) {
  const category = jsonData[categoryKey];
  const functionNames = category.functions.map((func) => func.unique_global_name);
  return functionNames;
}

// Get a list of the function group names (name used for overloaded functions)
function getFunctionGroups(categoryKey, jsonData) {
  const category = jsonData[categoryKey];
  const functionNames = category.functions.map((func) => func.name);
  return functionNames;
}

// Get the category description to display on the index page link cards
function getCategoryDescription(categoryKey, jsonData) {
  const category = jsonData[categoryKey];
  return category.brief.replace(/\n/g, '');
}

// Search the folders to get a list of paths for all available files in the /public/usage-examples/ folder
function getAllFiles(dir, allFilesList = []) {
  const files = fs.readdirSync(dir);
  files.map(file => {
    const name = dir + '/' + file;
    if (fs.statSync(name).isDirectory()) { // check if subdirectory is present
      getAllFiles(name, allFilesList);     // do recursive execution for subdirectory
    } else {
      allFilesList.push(file);             // push filename into the array
    }
  })
  return allFilesList;
}

// Create function link to match with functions in the API Documentation pages
function getFunctionLink(jsonData, groupNameToCheck, uniqueNameToCheck) {
  let isOverloaded;
  let functionIndex = -1;
  let functionLink = "";
  for (const categoryKey in jsonData) {
    const category = jsonData[categoryKey];
    const categoryFunctions = category.functions;
    const functionGroups = {}; // Store functions grouped by name
    categoryFunctions.forEach((func) => {
      const functionName = func.name;
      if (!functionGroups[functionName]) {
        functionGroups[functionName] = [];
      }
      functionGroups[functionName].push(func);
    });

    for (const functionName in functionGroups) {
      if (functionName == groupNameToCheck) {
        const overloads = functionGroups[functionName];
        isOverloaded = overloads.length > 1;

        if (isOverloaded) {
          overloads.forEach((func, index) => {
            functionIndex = index + 1;
            if (uniqueNameToCheck == func.unique_global_name) {
              functionLink = functionName + "-" + (index + 1);
            }
          });
        }
        else {
          functionLink = functionName;
        }
      }
    }
  }
  return functionLink;
}

// Clean directory function to remove all files except those in the exclusions list
// Resolves the issue of usage example mdx files being left behind when changing branches causing failures in builds
function cleanDirectory(directory, exclusions) {
  const files = fs.readdirSync(directory, { withFileTypes: true });
  files.forEach(file => {
    const fullPath = path.join(directory, file.name);
    if (file.isDirectory()) {
      cleanDirectory(fullPath, exclusions);  // Recursively clean directories
    } else if (!exclusions.includes(file.name)) {
      fs.unlinkSync(fullPath);  // Delete file if not in exclusions
      console.log(kleur.red(`Deleted:`) + ` ${fullPath}`);
    }
  });
}

console.log('Cleaning up directory for Usage examples pages...\n');
cleanDirectory(directoryToClean, filesToKeep);

// ===============================================================================
// Start of Main Script
// ===============================================================================

console.log("\nGenerating MDX files for Usage Examples pages...\n");

let name;
let success = true;
let testing = false;
let testingSuccess = true;
let testingOutput = "";
let fileNameToCheck = "";
// let simpleExample = false;

if (process.argv[2] != null) {
  fileNameToCheck = process.argv[2];
  testing = true;
}

let apiJsonData = getJsonData();
let categories = getApiCategories(apiJsonData);

// Loop through each category to create 1 page per category
categories.forEach((categoryKey) => {
  let categoryPath = '/usage-examples/' + categoryKey;
  let categoryFilePath = './public/usage-examples/' + categoryKey;
  const categoryFiles = getAllFiles(categoryFilePath);
  // Use .txt files to find completed usage examples
  const txtFiles = categoryFiles.filter(file => file.endsWith('.txt'))

  // Start of each page creation
  if (txtFiles.length > 0) {
    let mdxContent = "";

    // Create header info on page
    let categoryTitle = categoryKey.split("_")
      .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
      .join(" ");
    let categoryURL = categoryKey.replaceAll("_", "-");
    name = categoryTitle;
    mdxContent += "---\n";
    mdxContent += `title: ${categoryTitle}\n`;
    mdxContent += `description: ${getCategoryDescription(categoryKey, apiJsonData)}\n`;
    mdxContent += "sidebar:\n";
    mdxContent += `  label: ${categoryTitle}\n`;
    mdxContent += "banner:\n";
    mdxContent += `  content: Check out how to use the ${categoryTitle} functions!\n`;
    mdxContent += "---\n\n";

    mdxContent += `import { Code, Tabs, TabItem, LinkCard } from "@astrojs/starlight/components";\n`
    // mdxContent += `import { Code } from '@astrojs/starlight/components';\n`;
    mdxContent += `import Signatures from "/src/components/Signatures.astro";\n`;

    mdxContent += "\n:::note\n";
    mdxContent += `This page contains code examples of the [${categoryTitle}](/api/${categoryURL}) functions.\n`
    mdxContent += ":::\n\n";

    // Possible alternative
    // mdxContent += `\n<LinkCard\n`;
    // mdxContent += `  title="Related: ${categoryTitle} API Documention"\n`
    // mdxContent += `  href="/api/${categoryURL}"\n`
    // mdxContent += `/>\n\n`;

    // get function overload info
    let functionGroups = getFunctionGroups(categoryKey, apiJsonData);

    // get function info
    let functions = getUniqueFunctionNames(categoryKey, apiJsonData);
    let functionIndex = 0;
    let groupName = "";

    mdxContent += `## Simple Usage Examples\n`;
    const functionGroup = {};
    functions.forEach((functionKey) => {

      const functionExampleFiles = txtFiles.filter(file => file.startsWith(functionKey + '-'));
      groupName = functionGroups[functionIndex];

      if (functionExampleFiles.length > 0) {

        // Create function heading
        let functionTitle = functionKey.split("_")
          .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
          .join(" ");

        // Create Function Example heading with link
        const functionURL = getFunctionLink(apiJsonData, groupName, functionKey);

        // --- IN PROGRESS: Start ---

        // Note: Updating to use single heading with note about overloaded functions available

        // Check if overloaded
        // if (/\d/.test(functionURL) && groupName.includes("write_line")) {
        //   const categoryFunctions = apiJsonData[categoryKey].functions;
        //   const functionGroup = {};
        //   if (!functionGroup[groupName]) {
        //     functionGroup[groupName] = [];
        //   }
        //   categoryFunctions.forEach((func) => {
        //     const functionName = func.name;
        //     const uniqueName = func.unique_global_name;

        //     if (uniqueName.endsWith(functionKey) && functionName == groupName) {
        //       functionGroup[functionName].push(func);
        //     }
        //   });
        //   console.log(functionGroup);

        // mdxContent += `\n### [${functionTitle}](/api/${categoryURL}/#${groupName.replaceAll("_", "-")})\n\n`;
        // mdxContent += ":::note\n\n";
        // mdxContent += "This function is overloaded. The following versions exist:\n\n";

        //   overloads.forEach((func, index) => {
        //     mdxContent += `- [**${formattedFunctionName}** (`;

        //     var paramCount = Object.keys(func.parameters).length;
        //     var paramNumber = 1;

        //     for (const paramName in func.parameters) {
        //       const param = func.parameters[paramName];
        //       const paramType = param.type;
        //       if (index > 0) {
        //         mdxContent += "";
        //       }

        //       // mdxContent += `${paramName}: ${paramType}, `;

        //       mdxContent += `${paramName}: ${paramType}`;
        //       if (paramNumber < paramCount) {
        //         mdxContent += ", "
        //       }
        //       paramNumber++;
        //     }
        //     mdxContent += `)](/api/${categoryKey}/#${formattedLink.toLowerCase()}-${index + 1})\n`;
        //   });

        //   mdxContent += "\n:::\n";

        // }

        // --- IN PROGRESS: End ---

        mdxContent += `\n### [${functionTitle}](/api/${categoryURL}/#${functionURL.replaceAll("_", "-")})\n\n`;

        // Function signature heading (possible need to update)
        const signature = apiJsonData[categoryKey].functions.map((func) => func.signature)[functionIndex].replaceAll(";", "");
        mdxContent += `:::tip[Note]\n`;
        mdxContent += `The example(s) below are using the **${functionTitle}** function with the following signatures:\n\n`
        mdxContent += `<Signatures name="${functionKey.replaceAll("_", "-")}">\n`;
        mdxContent += `</Signatures>\n`;
        mdxContent += "\n:::\n";

        functionExampleFiles.forEach((exampleTxtKey) => {
          let exampleKey = exampleTxtKey.replaceAll(".txt", "");

          // -----------------------------------
          // ========= TESTING =================
          // -----------------------------------
          // Testing that all files are included for filename (terminal argument)
          if (fileNameToCheck == exampleKey) {

            // Define required code files
            const requiredCodeFiles = {
              ".cpp": "C++\t\t",
              "-top-level.cs": "C# (Top-Level)",
              "-oop.cs": "C# (Object-Oriented)",
              ".py": "Python\t",
              // ".pas": "Pascal",
            };

            let exampleFiles = categoryFiles.filter(file => file.startsWith(exampleKey));

            testingOutput += "\n------------------------------------------------\n\n";
            testingOutput += kleur.magenta("Testing") + kleur.cyan(" -> " + fileNameToCheck) + "\n\n";

            // Text file - check already done above
            testingOutput += kleur.green("\u2705 Text Description\t -> ") + kleur.white(fileNameToCheck + ".txt\n");

            // Check for output file (.png or .gif)
            if (exampleFiles.includes(fileNameToCheck + ".png")) {
              testingOutput += kleur.green("\u2705 Image\t\t -> ") + kleur.white(fileNameToCheck + ".png\n");
            } else if (exampleFiles.includes(fileNameToCheck + ".gif")) {
              testingOutput += kleur.green("\u2705 Image (Gif)\t\t -> ") + kleur.white(fileNameToCheck + ".gif\n");
            } else {
              testingOutput += kleur.red("\u274C Image/Gif\t\t -> ") + kleur.white(fileNameToCheck + " .png or .gif file\n");
              testingSuccess = false;
            }

            // Check code files
            Object.keys(requiredCodeFiles).forEach(function (extension) {
              if (exampleFiles.includes(fileNameToCheck + extension)) {
                testingOutput += kleur.green("\u2705 " + requiredCodeFiles[extension] + "\t -> ") + kleur.white(fileNameToCheck + extension + "\n");
              } else {
                testingOutput += kleur.red("\u274C " + requiredCodeFiles[extension] + "\t -> ") + kleur.white(fileNameToCheck + extension + "\n");
                testingSuccess = false;
              }
            });

            if (!testingSuccess) {
              testingOutput += "\nSome files missing or incorrectly named (shown in red above).\nPlease update to make sure you have all files listed above and try again.\n"
            }

            testingOutput += "\n------------------------------------------------\n";
          }
          // -----------------------------------

          // Description
          let txtFilePath = categoryFilePath + "/" + functionKey + "/" + exampleTxtKey;
          let exampleTxt = fs.readFileSync(txtFilePath);
          mdxContent += "\n";
          mdxContent += exampleTxt.toString();
          mdxContent += "\n\n";

          let languageCodeAvailable = {
            cpp: false,
            csharp: false,
            python: false,
            // pascal: false
          };

          // import code
          let codePath = categoryFilePath + "/" + functionKey;
          const codeFiles = getAllFiles(codePath);
          let importTitle = exampleKey.replaceAll("-", "_");
          let functionTag = "";
          languageOrder.forEach((lang) => {
            const languageFiles = codeFiles.filter(file => file.startsWith(exampleKey)).filter(file => file.endsWith(languageFileExtensions[lang]));
            let codeFilePath = categoryPath + "/" + functionKey + "/" + exampleTxtKey.replaceAll(".txt", languageFileExtensions[lang]);

            // import code if available
            if (languageFiles.length > 0) {
              languageCodeAvailable[lang] = true;

              // Check if both top level and oop code has been found for current function
              const csharpFiles = codeFiles.filter(file => file.endsWith("-top-level.cs") || file.endsWith("-oop.cs")).filter(file => file.includes(exampleKey));
              if (lang == "csharp" && csharpFiles.length > 0) {
                csharpFiles.forEach(file => {
                  if (file.includes(exampleKey)) {
                    if (file.includes("-top-level")) {
                      mdxContent += `import ${importTitle}_top_level_${lang} from '${codeFilePath.replaceAll(".cs", "-top-level.cs").replaceAll("/usage", "/public/usage")}?raw';\n`;
                    }
                    if (file.includes("-oop")) {
                      mdxContent += `import ${importTitle}_oop_${lang} from '${codeFilePath.replaceAll(".cs", "-oop.cs").replaceAll("/usage", "/public/usage")}?raw';\n`;
                    }
                  }
                });
              }
              else {
                mdxContent += `import ${importTitle}_${lang} from '${codeFilePath.replaceAll("/usage", "/public/usage")}?raw';\n`;
              }
            }
          });

          mdxContent += "\n";

          // Code tabs
          mdxContent += "<Tabs syncKey=\"code-language\">\n";
          languageOrder.forEach((lang) => {
            // add code tab if available
            if (languageCodeAvailable[lang]) {
              const languageLabel = languageLabelMappings[lang] || lang;
              mdxContent += `  <TabItem label="${languageLabel}">\n`;

              // Check if both top level and oop code has been found for current function
              const csharpFiles = codeFiles.filter(file => file.endsWith("-top-level.cs") || file.endsWith("-oop.cs")).filter(file => file.includes(exampleKey));
              functionTag = exampleKey.split("-")[0];
              if (lang == "cpp") {
                functionTag = groupName;
              }
              if (lang == "csharp") {
                functionTag = groupName.split("_")
                  .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
                  .join("");
              }
              if (lang == "csharp" && csharpFiles.length > 0) {
                mdxContent += "\n  <Tabs syncKey=\"csharp-style\">\n";
                // use reverse order to make Top level first
                csharpFiles.slice().reverse().forEach(file => {
                  if (file.includes(exampleKey)) {
                    if (file.includes("-top-level")) {
                      mdxContent += `    <TabItem label="Top-level Statements">\n`;
                      mdxContent += `      <Code code={${importTitle}_top_level_${lang}} lang="${lang}" mark={"${functionTag}"} />\n`;
                      mdxContent += "    </TabItem>\n";
                    }
                    if (file.includes("-oop")) {
                      mdxContent += `    <TabItem label="Object-Oriented">\n`;
                      mdxContent += `      <Code code={${importTitle}_oop_${lang}} lang="${lang}" mark={"SplashKit.${functionTag}"} />\n`;
                      mdxContent += "    </TabItem>\n";
                    }
                  }
                });
                mdxContent += "  </Tabs>\n\n";
                mdxContent += "  </TabItem>\n";
              }
              else {
                mdxContent += `    <Code code={${importTitle}_${lang}} lang="${lang}" mark={"${functionTag}"} />\n`;
                mdxContent += "  </TabItem>\n";
              }
            }

          });
          mdxContent += "</Tabs>\n\n";

          // Image or gif output
          mdxContent += "**Output**:\n\n";

          const imageFiles = categoryFiles.filter(file => file.endsWith(exampleKey + '.png'));
          let outputFilePath = categoryPath + "/" + functionKey + "/" + exampleTxtKey;
          // Check for .png files
          if (imageFiles.length > 0) {
            outputFilePath = outputFilePath.replaceAll(".txt", ".png");
            mdxContent += `![${exampleKey} example](${outputFilePath})\n`
          }
          else {
            const gifFiles = categoryFiles.filter(file => file.endsWith('.gif')).filter(file => file.startsWith(exampleKey));
            // Check for .gif files
            if (gifFiles.length > 0) {
              outputFilePath = outputFilePath.replaceAll(".txt", ".gif");
              mdxContent += `![${exampleKey} example](${outputFilePath})\n`
            }
            else {
              const webmFiles = categoryFiles.filter(file => file.endsWith('.webm'));
              // Check for .webm files
              if (webmFiles.length > 0) {
                outputFilePath = outputFilePath.replaceAll(".txt", ".webm");
                mdxContent += `<video controls style="max-width:100%; margin:auto; margin-top:16px;">\n`
                mdxContent += `\t<source src="${outputFilePath}" type="video/webm" />\n`
                mdxContent += `</video>\n`
              }
              else {
                console.log(kleur.red("\nError: No image, gif or webm (audio) files found for " + exampleKey + "usage example"));
              }
            }
          }
          mdxContent += "\n---\n";
        });
      }
      functionIndex++;
    });

    // Write the MDX file
    try {
      fs.writeFileSync(`./src/content/docs/usage-examples/${name}.mdx`, mdxContent);
      console.log(kleur.yellow('Usage Examples') + kleur.green(` -> ${categoryKey.split("_")
        .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
        .join(" ")}`));
    } catch (err) {
      success = false;
      console.log(kleur.red(`Error writing ${categoryKey} MDX file: `) + `${err.message}`);
      return;
    }
  }
});

// Check if all MDX files generated successfully
if (success) {
  console.log(kleur.green("\nAll Usage Example MDX files generated successfully."));
}
// Output information when checking filename
if (testing) {
  console.log(testingOutput);
}
