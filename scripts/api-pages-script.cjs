// ------------------------------------------------------------------------------
// Script to generate .mdx files in the "/src/content/docs/api" folder,
// using a specific format to adapt to markdown from JSON data.

// Authors: @XQuestCode, @omckeon, and @thoth-tech members
// ------------------------------------------------------------------------------

// ------------------------------------------------------------------------------
// Imports
// ------------------------------------------------------------------------------
const fs = require("fs");
const kleur = require("kleur");
const path = require('path');

// ------------------------------------------------------------------------------
// Constants
// ------------------------------------------------------------------------------
// For cleaning files from usage-examples folder
const directoryToClean = 'src/content/docs/api';
const filesToKeep = ['index.mdx'];

// Define type mappings
const typeMappings = {
  int: "`Integer`",
  double: "`Double`",
  bool: "`Boolean`",
  char: "`Char`",
  string: "`String`",
  void: "`Void`",
  float: "`Float`",
  vector: "`Vector`",
  // Add more type mappings as needed
};

const guidesAvailable = {
  animations: false,
  audio: false,
  camera: false,
  database: false,
  inputs: false,
  json: false,
  networking: false,
  physics: false,
  sprites: false,
  utilities: false
};

// Define language label mappings
const languageLabelMappings = {
  pascal: "Pascal",
  python: "Python",
  cpp: "C++",
  csharp: "C#",
  // Add more mappings as needed
};

// Define language file extensions
const languageFileExtensions = {
  cpp: ".cpp",
  csharp: ".cs",
  python: ".py",
  pascal: ".pas"
};

// Define language order
const languageOrder = ["cpp", "csharp", "python", "pascal"];
var name = "";

const sk_colors = ["alice_blue", "antique_white", "aqua", "aquamarine", "azure", "beige", "bisque", "black", "blanched_almond", "blue", "blue_violet", "bright_green", "brown", "burly_wood", "cadet_blue", "chartreuse", "chocolate", "coral", "cornflower_blue", "cornsilk", "crimson", "cyan", "dark_blue", "dark_cyan", "dark_goldenrod", "dark_gray", "dark_green", "dark_khaki", "dark_magenta", "dark_olive_green", "dark_orange", "dark_orchid", "dark_red", "dark_salmon", "dark_sea_green", "dark_slate_blue", "dark_slate_gray", "dark_turquoise", "dark_violet", "deep_pink", "deep_sky_blue", "dim_gray", "dodger_blue", "firebrick", "floral_white", "forest_green", "fuchsia", "gainsboro", "ghost_white", "gold", "goldenrod", "gray", "green", "green_yellow", "honeydew", "hot_pink", "indian_red", "indigo", "ivory", "khaki", "lavender", "lavender_blush", "lawn_green", "lemon_chiffon", "light_blue", "light_coral", "light_cyan", "light_goldenrod_yellow", "light_gray", "light_green", "light_pink", "light_salmon", "light_sea_green", "light_sky_blue", "light_slate_gray", "light_steel_blue", "light_yellow", "lime", "lime_green", "linen", "magenta", "maroon", "medium_aquamarine", "medium_blue", "medium_orchid", "medium_purple", "medium_sea_green", "medium_slate_blue", "medium_spring_green", "medium_turquoise", "medium_violet_red", "midnight_blue", "mint_cream", "misty_rose", "moccasin", "navajo_white", "navy", "old_lace", "olive", "olive_drab", "orange", "orange_red", "orchid", "pale_goldenrod", "pale_green", "pale_turquoise", "pale_violet_red", "papaya_whip", "peach_puff", "peru", "pink", "plum", "powder_blue", "purple", "red", "rosy_brown", "royal_blue", "saddle_brown", "salmon", "sandy_brown", "sea_green", "sea_shell", "sienna", "silver", "sky_blue", "slate_blue", "slate_gray", "snow", "spring_green", "steel_blue", "swinburne_red", "tan", "teal", "thistle", "tomato", "transparent", "turquoise", "violet", "wheat", "white", "white_smoke", "yellow", "yellow_green"];

// ------------------------------------------------------------------------------
// Functions
// ------------------------------------------------------------------------------

// ------------------------------------------------------------------------------
// Get a list of all the files in a directory and it's subdirectories
// ------------------------------------------------------------------------------
function getAllFiles(dir, allFilesList = []) {
  try {
    const files = fs.readdirSync(dir);
    files.map(file => {
      const name = dir + '/' + file;
      if (fs.statSync(name).isDirectory()) { // check if subdirectory is present
        getAllFiles(name, allFilesList);     // do recursive execution for subdirectory
      } else {
        allFilesList.push(file);             // push filename into the array
      }
    })
  } catch (err) {
    console.error(kleur.yellow(`Warning: Unable to access directory ${dir}`), err);
  }
  return allFilesList;
}

// ------------------------------------------------------------------------------
// Get list of all finished examples
// ------------------------------------------------------------------------------
function getAllFinishedExamples() {
  var apiJsonData;
  try {
    var apiData = fs.readFileSync(`${__dirname}/json-files/api.json`);
    apiJsonData = JSON.parse(apiData);
  } catch (error) {
    console.error(kluer.red("Error occurred when trying to parse API Json data: ", error));
  }

  const categories = []
  for (const categoryKey in apiJsonData) {
    if (categoryKey != "types") {
      categories.push(categoryKey);
    }
  }

  const allExamples = [];

  categories.forEach((categoryKey) => {
    const categoryFilePath = path.join(path.dirname(__dirname), "public", "usage-examples", categoryKey);
    const categoryFiles = getAllFiles(categoryFilePath);

    // Filter for .txt files
    const txtFiles = categoryFiles.filter(file => file.endsWith('.txt'));

    // Extract the portion before the first '-'
    if (txtFiles.length > 0) {
      txtFiles.forEach((file) => {
        allExamples.push(file);
      });
    }
  });

  return allExamples;
}

// ------------------------------------------------------------------------------
// Type Mappings
// ------------------------------------------------------------------------------
function Mappings(jsonData) {
  //generate mappings from API
  for (const categoryKey in jsonData) {
    const category = jsonData[categoryKey];
    category.typedefs.forEach((typedef) => {
      // Add typedef to typeMappings
      const name = typedef.name.split("_")
        .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
        .join(" ");

      typeMappings[typedef.name] = `[\`${name}\`](/api/${categoryKey.toLowerCase().replace(/\s+/g, "-")}/#${name.toLowerCase().replace(/\s+/g, "-")})`;
    });
    category.structs.forEach((struct) => {
      // Add structs to typeMappings
      const name = struct.name.split("_")
        .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
        .join(" ");

      typeMappings[struct.name] = `[\`${name}\`](/api/${categoryKey.toLowerCase().replace(/\s+/g, "-")}/#${name.toLowerCase().replace(/\s+/g, "-")})`;
    });
    category.enums.forEach((enumm) => {
      // Add structs to typeMappings
      const name = enumm.name.split("_")
        .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
        .join(" ");

      typeMappings[enumm.name] = `[\`${name}\`](/api/${categoryKey.toLowerCase().replace(/\s+/g, "-")}/#${name.toLowerCase().replace(/\s+/g, "-")})`;
    });
  }
}

// ------------------------------------------------------------------------------
// Regex pattern for extracting the enums from the api.json signatures
// ------------------------------------------------------------------------------
function extractEnumValues(signature, language) {
  const details = [];
  let regex;

  if (language === 'cpp') {
    regex = /(\w+)\s*=\s*/g; // Handles the cpp pattern which has no dot in the name
  } else {
    regex = /(\w+\.\w+)\s*=\s*/g; // Handles the other languages which have a dot in the name
  }

  let match;
  while (match = regex.exec(signature)) {
    details.push(match[1]);
  }
  return details;
}

// ------------------------------------------------------------------------------
// Get Color RGB values from json file
// ------------------------------------------------------------------------------
function getColorRGBValues(colorName, jsonData) {
  const simplifiedName = colorName.replace("color_", "");

  const colorData = jsonData[simplifiedName];
  let rgbValues = '( 0, 0, 0)';
  if (colorData != undefined) {
    rgbValues = colorData.rgb;
  }
  return rgbValues;
}

// ------------------------------------------------------------------------------
// Get JSON data from .json file
// ------------------------------------------------------------------------------
function getJsonData(jsonFileName) {
  var jsonFile;
  var jsonData;
  try {
    jsonFile = fs.readFileSync(`${__dirname}/json-files/${jsonFileName}`);
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

// ------------------------------------------------------------------------------
// Get API categories from JSON data
// ------------------------------------------------------------------------------
function getApiCategories(jsonData) {
  const apiCategories = [];
  for (const categoryKey in jsonData) {
    if (categoryKey != "types") {
      apiCategories.push(jsonData[categoryKey]);
    }
  }
  return apiCategories;
}

// ------------------------------------------------------------------------------
// Import Code for Usage example content
// ------------------------------------------------------------------------------
function getUsageExampleImports(categoryKey, functionKey) {
  let languageCodeAvailable = {
    cpp: false,
    csharp: false,
    python: false,
    // pascal: false
  };
  let mdxData = "";
  let categoryPath = '/usage-examples/' + categoryKey;
  let categoryFilePath = './public/usage-examples/' + categoryKey;

  const functionFiles = getAllFiles(categoryFilePath).filter(file => file.startsWith(functionKey));
  if (functionFiles.length > 0) {
    const txtFiles = functionFiles.filter(file => file.endsWith('.txt'))
    if (txtFiles.length > 0) {
      txtFiles.forEach((exampleTxtKey) => {
        let exampleKey = exampleTxtKey.replaceAll(".txt", "");

        let importTitle = exampleKey.replaceAll("-", "_");

        languageOrder.forEach((lang) => {
          const languageFiles = functionFiles.filter(file => file.endsWith(languageFileExtensions[lang]));
          let codeFilePath = categoryPath + "/" + exampleTxtKey.replaceAll(".txt", languageFileExtensions[lang]);

          // import code if available
          if (languageFiles.length > 0) {
            languageCodeAvailable[lang] = true;

            // Check if both top level and oop code has been found for current function
            const csharpFiles = functionFiles.filter(file => file.endsWith("-top-level.cs") || file.endsWith("-oop.cs")).filter(file => file.includes(exampleKey));
            const cppFiles = functionFiles.filter(file => file.endsWith("-sk.cpp") || file.endsWith("-beyond.cpp")).filter(file => file.includes(exampleKey));
            if (lang == "csharp" && csharpFiles.length > 0) {
              csharpFiles.forEach(file => {
                if (file.includes(exampleKey)) {
                  if (file.includes("-top-level")) {
                    mdxData += `import ${importTitle}_top_level_${lang} from '${codeFilePath.replaceAll(".cs", "-top-level.cs").replaceAll("/usage", "/public/usage")}?raw';\n`;
                  }
                  if (file.includes("-oop")) {
                    mdxData += `import ${importTitle}_oop_${lang} from '${codeFilePath.replaceAll(".cs", "-oop.cs").replaceAll("/usage", "/public/usage")}?raw';\n`;
                  }
                }
              });
            } // Check for cpp files for standard SK and Beyond SK
            else if (lang == "cpp" && cppFiles.length > 0) {
              cppFiles.forEach(file => {
                if (file.includes(exampleKey)) {
                  if (file.includes("-sk")) {
                    mdxData += `import ${importTitle}_sk_${lang} from '${codeFilePath.replaceAll(".cpp", "-sk.cpp").replaceAll("/usage", "/public/usage")}?raw';\n`;
                  }
                  if (file.includes("-beyond")) {
                    mdxData += `import ${importTitle}_beyond_${lang} from '${codeFilePath.replaceAll(".cpp", "-beyond.cpp").replaceAll("/usage", "/public/usage")}?raw';\n`;
                  }
                }
              });
            }
            else {
              mdxData += `import ${importTitle}_${lang} from '${codeFilePath.replaceAll("/usage", "/public/usage")}?raw';\n`;
            }
          }
        });
      });
    }
  }
  mdxData += "\n";
  return mdxData;
}

// ------------------------------------------------------------------------------
// Get group name (C++ function name) from unique global name
// ------------------------------------------------------------------------------
function getGroupName(jsonData, uniqueName) {
  var funcGroupName = ""
  for (const categoryKey in jsonData) {
    const category = jsonData[categoryKey];
    const categoryFunctions = category.functions;
    categoryFunctions.forEach((func) => {
      if (func.unique_global_name == uniqueName) {
        funcGroupName = func.name.split("_").map((word) => word.charAt(0).toUpperCase() + word.slice(1)).join(" ");;
      }
    });
  }
  return funcGroupName;
}

// ------------------------------------------------------------------------------
// Get mdx string for Usage example content (with code tabs etc)
// ------------------------------------------------------------------------------
function getUsageExampleContent(jsonData, categoryKey, groupName, functionKey) {
  let languageCodeAvailable = {
    cpp: false,
    csharp: false,
    python: false,
    // pascal: false
  };
  let mdxData = "";
  let categoryPath = '/usage-examples/' + categoryKey;
  let categoryFilePath = './public/usage-examples/' + categoryKey;

  let exampleKey = functionKey.replaceAll(".txt", "");
  const functionFiles = getAllFiles(categoryFilePath).filter(file => file.startsWith(exampleKey));

  if (functionFiles.length > 0) {

    const functionExampleFiles = functionFiles.filter(file => file.endsWith(".txt"));
    functionExampleFiles.forEach((exampleTxtKey) => {

      // import code if available
      if (functionFiles.length > 0) {
        let importTitle = exampleKey.replaceAll("-", "_");

        // Description
        let exampleNum = exampleKey.replace(/\D/g, '');
        mdxData += `**Example ${exampleNum}**: `;
        let exampleTxt = fs.readFileSync(categoryFilePath + "/" + exampleTxtKey);
        mdxData += exampleTxt.toString();
        mdxData += "\n\n";

        // Code tabs
        mdxData += "<Tabs syncKey=\"code-language\">\n";
        languageOrder.forEach((lang) => {
          const languageFiles = functionFiles.filter(file => file.startsWith(exampleKey)).filter(file => file.endsWith(languageFileExtensions[lang]));

          if (languageFiles.length > 0) {
            languageCodeAvailable[lang] = true;
            // add code tab if available
            if (languageCodeAvailable[lang]) {
              const languageLabel = languageLabelMappings[lang] || lang;
              mdxData += `  <TabItem label="${languageLabel}">\n`;

              // Check if both top level and oop code has been found for current function
              const csharpFiles = functionFiles.filter(file => file.endsWith("-top-level.cs") || file.endsWith("-oop.cs")).filter(file => file.includes(exampleKey));
              const cppFiles = functionFiles.filter(file => file.endsWith("-sk.cpp") || file.endsWith("-beyond.cpp")).filter(file => file.includes(exampleKey));
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
                mdxData += "\n  <Tabs syncKey=\"csharp-style\">\n";
                // use reverse order to make Top level first
                csharpFiles.slice().reverse().forEach(file => {
                  if (file.includes(exampleKey)) {
                    if (file.includes("-top-level")) {
                      mdxData += `    <TabItem label="Top-level Statements">\n`;
                      mdxData += `      <Code code={${importTitle}_top_level_${lang}} lang="${lang}" mark={"${functionTag}"} />\n`;
                      mdxData += "    </TabItem>\n";
                    }
                    if (file.includes("-oop")) {
                      mdxData += `    <TabItem label="Object-Oriented">\n`;
                      mdxData += `      <Code code={${importTitle}_oop_${lang}} lang="${lang}" mark={"SplashKit.${functionTag}"} />\n`;
                      mdxData += "    </TabItem>\n";
                    }
                  }
                });
                mdxData += "  </Tabs>\n\n";
                mdxData += "  </TabItem>\n";
              }
              // Check for cpp files and generate nested tabs
              else if (lang == "cpp" && cppFiles.length > 0) {
                mdxData += "  </TabItem>\n";
              }
              else {
                mdxData += `    <Code code={${importTitle}_${lang}} lang="${lang}" mark={"${functionTag}"} />\n`;
                mdxData += "  </TabItem>\n";
              }
            }
          }
        });
      }
      mdxData += "</Tabs>\n\n";

      // Image or gif output
      mdxData += "**Output**:\n\n";

      let outputFilePath = categoryPath + "/" + exampleTxtKey;


      const imageFiles = functionFiles.filter(file => file.endsWith(exampleKey + '.png'));
      // Check for .png files
      if (imageFiles.length > 0) {
        outputFilePath = outputFilePath.replaceAll(".txt", ".png");
        mdxData += `![${exampleKey} example](${outputFilePath})\n`
      }
      else {
        const gifFiles = functionFiles.filter(file => file.endsWith('.gif')).filter(file => file.startsWith(exampleKey));
        // Check for .gif files
        if (gifFiles.length > 0) {
          outputFilePath = outputFilePath.replaceAll(".txt", ".gif");
          mdxData += `![${exampleKey} example](${outputFilePath})\n`
        }
        else {
          const webmFiles = functionFiles.filter(file => file.endsWith('.webm'));
          // Check for .webm files
          if (webmFiles.length > 0) {
            outputFilePath = outputFilePath.replaceAll(".txt", ".webm");
            mdxData += `<video controls style="max-width:100%; margin:auto; margin-top:16px;">\n`
            mdxData += `\t<source src="${outputFilePath}" type="video/webm" />\n`
            mdxData += `</video>\n`
          }
          else {
            console.log(kleur.red("\nError: No image, gif or webm (audio) files found for " + exampleKey + " usage example"));
          }
        }
      }
    });
  }
  return mdxData;
}

// ------------------------------------------------------------------------------
// Clean directory to remove all files except those in the exclusions list
// ------------------------------------------------------------------------------
function cleanDirectory(directory, exclusions) {
  const files = fs.readdirSync(directory, { withFileTypes: true });
  files.forEach(file => {
    const fullPath = path.join(directory, file.name);
    if (file.isDirectory()) {
      cleanDirectory(fullPath, exclusions);  // Recursively clean directories
    } else if (!exclusions.includes(file.name)) {
      fs.unlinkSync(fullPath);  // Delete file if not in exclusions
      console.log(kleur.red(`  Deleted: `) + kleur.dim(`${fullPath}`));
    }
  });
}

// ==============================================================================
// ========================= START of main script ===============================
// ==============================================================================

console.log(kleur.cyan('------------------------------------------------------------------------------'));
console.log(kleur.magenta('API Documentation mdx pages Generation:'));
console.log(kleur.cyan('------------------------------------------------------------------------------\n'));

console.log('Cleaning up directory for API Documentation pages...');
cleanDirectory(directoryToClean, filesToKeep);

let mdxContent = "";
let success = true;
const jsonData = getJsonData("api.json");
const jsonColors = getJsonData("colors.json");
let guidesJson = getJsonData("guides.json");
let usageExamplesJson = getJsonData("usage-example-references.json");
let guidesCategories = getApiCategories(guidesJson);
let examplesCategories = getApiCategories(usageExamplesJson);
const usageExamples = getAllFinishedExamples();

Mappings(jsonData);
console.log(`\nGenerating MDX files for API Documentation pages...\n`);

// Please select an option: "animations, audio, camera, color, geometry, graphics, input, json, networking, physics, resource_bundles, resources, sprites, terminal, timers, types, utilities, windows"
for (const categoryKey in jsonData) {
  const category = jsonData[categoryKey];
  let input = categoryKey;
  const categoryFunctions = category.functions;
  let mdxContent = "";
  name = input.split("_")
    .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
    .join(" "); //name of the category
  const functionNames = category.functions.map((func) => func.name);

  mdxContent += "---\n";
  mdxContent += `title: ${name}\n`;
  if (category.brief != "") { mdxContent += `description: ${category.brief.replace(/\n/g, '')}\n`; }
  else { mdxContent += `description: Some description....\n`; }

  mdxContent += "---\n\n";
  if (category.brief != "") {
    if (categoryFunctions.description != null) {
      mdxContent += `:::tip[${category.brief}]\n`;
      mdxContent += `${category.description}\n`
      mdxContent += `:::\n`
    }
    else {
      mdxContent += `:::tip[${name}]\n`;
      mdxContent += `${category.brief}\n`
      mdxContent += `:::\n`
    }
  }
  mdxContent += `\nimport { Code, Tabs, TabItem, LinkCard, CardGrid, LinkButton } from "@astrojs/starlight/components";\nimport Accordion from '../../../components/Accordion.astro'\n`;
  if (guidesAvailable[categoryKey]) {
    mdxContent += "\n## \n";
    mdxContent += `## ${name} Guides\n`;
    mdxContent += `<LinkCard
        title="Using ${name}"
        description="Examples & Guides"
        href="/guides/${input}/"
        />\n\n`;
  }
  mdxContent += "\n";
  mdxContent += "## Functions\n";
  // mdxContent += "\n";
  const functionGroups = {}; // Store functions grouped by name
  categoryFunctions.forEach((func) => {
    const functionName = func.name;
    if (!functionGroups[functionName]) {
      functionGroups[functionName] = [];
    }
    functionGroups[functionName].push(func);
  });


  for (const functionName in functionGroups) {
    const overloads = functionGroups[functionName];
    const isOverloaded = overloads.length > 1;

    const hasExampleInGroup = functionGroups[functionName].some((func) =>
      usageExamples.some((example) =>
        example.startsWith(func.unique_global_name + "-1-example.txt")
      )
    );

    const hasExampleReferenceInGroup = functionGroups[functionName].some((func) =>
      examplesCategories.some((category) =>
        category.some((example) =>
          example.functions.includes(func.unique_global_name)
        )
      )
    );

    const hasGuideInGroup = functionGroups[functionName].some((func) =>
      guidesCategories.some((category) =>
        category.some((guide) =>
          guide.functions.includes(func.unique_global_name)
        )
      )
    );

    // Create a section for overloaded functions
    if (isOverloaded) {
      const formattedFunctionName = functionName
        .split("_")
        .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
        .join(" ");
      const formattedLink = formattedFunctionName.toLowerCase().replace(/\s+/g, "-");

      // Put {</>} symbol at the end of header if function has a usage example
      const hasSymbol = (hasExampleInGroup || hasGuideInGroup || hasExampleReferenceInGroup) ? `&nbsp;&nbsp;&lcub;&lt;/&gt;&rcub;` : "";
      const formattedGroupLink = `${formattedLink}-functions`;

      mdxContent += `\n### [${formattedFunctionName}](#${formattedGroupLink})${hasSymbol} \\{#${formattedGroupLink}\\}\n\n`;

      mdxContent += ":::note\n\n";
      mdxContent += "This function is overloaded. The following versions exist:\n\n";

      overloads.forEach((func, index) => {
        mdxContent += `- [**${formattedFunctionName}** (`;

        var paramCount = Object.keys(func.parameters).length;
        var paramNumber = 1;

        for (const paramName in func.parameters) {
          const param = func.parameters[paramName];
          const paramType = param.type;
          if (index > 0) {
            mdxContent += "";
          }

          // mdxContent += `${paramName}: ${paramType}, `;

          mdxContent += `${paramName}: ${paramType}`;
          if (paramNumber < paramCount) {
            mdxContent += ", "
          }
          paramNumber++;
        }
        const formattedUniqueLink = func.unique_global_name.toLowerCase().replace(/_/g, "-");
        mdxContent += `)](/api/${input}/#${formattedUniqueLink})`;

        // Put bolded {</>} symbol at the end of heading link if function has a usage example
        const hasExample = usageExamples.some(example => example.startsWith(func.unique_global_name + "-1-example.txt"));
        const hasGuide = guidesCategories.some((category) => category.some((guide) => guide.functions.includes(func.unique_global_name)));
        const hasExampleReference = examplesCategories.some((category) => category.some((example) => example.functions.includes(func.unique_global_name)));

        if (hasExample || hasGuide || hasExampleReference) {
          mdxContent += "&nbsp;&nbsp;<strong>&lcub;&lt;/&gt;&rcub;</strong>";
        }

        mdxContent += `\n`;
      });

      mdxContent += "\n:::\n";
    }

    overloads.forEach((func, index) => {
      // Format the header based on whether it's overloaded or not
      let functionName2 = functionName.split("_")
        .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
        .join(" ");
      const formattedName3 = func.name
        .split("_")
        .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
        .join(" ");

      const formattedLink = formattedName3.toLowerCase().replace(/\s+/g, "-");
      const formattedUniqueLink = func.unique_global_name.toLowerCase().replace(/_/g, "-");
      const hasExample = usageExamples.some(example => example.startsWith(func.unique_global_name + "-1-example.txt"));
      const hasGuide = guidesCategories.some((category) => category.some((guide) => guide.functions.includes(func.unique_global_name)));
      const hasExampleReference = examplesCategories.some((category) => category.some((example) => example.functions.includes(func.unique_global_name)));
      const hasSymbol = (hasExample || hasGuide || hasExampleReference) ? `&nbsp;&nbsp;&lcub;&lt;/&gt;&rcub;` : "";
      // Put {</>} symbol at the end of headers of overloaded functions with usage example or else just keep empty
      const formattedName = isOverloaded
        ? `\n#### [${functionName2}](#${formattedUniqueLink})${hasSymbol} \\{#${formattedUniqueLink}\\}`
        : `\n### [${functionName2}](#${formattedLink})${hasSymbol}`;

      // Replace type names in the description with formatted versions
      let description = func.description || "";
      for (const typeName in typeMappings) {
        const typeMapping = typeMappings[typeName];
        description = description.replace(
          new RegExp(`\`\\b${typeName}\\b\``, "g"),
          typeMapping
        );
      }

      // Color boxes next to heading
      if (functionName.startsWith("color_") && sk_colors.includes(functionName.replace("color_", ""))) {
        mdxContent += `\n#### <span style="display:none;">${functionName2}</span>\n` // Added to fix links validator issue
        mdxContent += `${formattedName}`;
        const rgbValues = getColorRGBValues(functionName, jsonColors);
        mdxContent += ` <div class='color-box' style="background:rgba${rgbValues}"></div>`
      }
      else {
        mdxContent += `${formattedName}`;
      }

      mdxContent += "\n\n";

      for (const names of functionNames) {
        const normalName = names
          .split("_")
          .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
          .join(" ");
        const formattedLink = normalName.toLowerCase().replace(/\s+/g, "-");
        const link = `[\`${normalName}\`](/api/${input}/#${formattedLink})`
        description = description.replace(new RegExp(`\`\\b${names}\\b\``, "g"), link);
        description = description.replaceAll("\n", " ");
      }
      mdxContent += description ? `${description}\n\n` : "";

      // Add Parameters section only if there are parameters
      if (Object.keys(func.parameters).length > 0) {
        mdxContent += "**Parameters:**\n\n";
        mdxContent += `<div class="function-parameters-list">\n\n`;
        mdxContent +=
          "| Name   | Type                                               | Description                                                                        |\n";
        mdxContent +=
          "| ------ | -------------------------------------------------- | ---------------------------------------------------------------------------------- |\n";

        for (const paramName in func.parameters) {
          const param = func.parameters[paramName];
          let paramType = typeMappings[param.type] || param.type;
          if (paramType == 'unsigned int') {
            paramType = "`Unsigned Integer`";
          }
          let description2 = param.description || "";
          for (const typeName in typeMappings) {
            const typeMapping = typeMappings[typeName];

            description2 = description2.replace(
              new RegExp(`\`\\b${typeName}\\b\``, "g"),
              typeMapping
            );
          }

          for (const names of functionNames) {
            const normalName = names
              .split("_")
              .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
              .join(" ");
            const formattedLink = normalName.toLowerCase().replace(/\s+/g, "-");
            const link = `[\`${normalName}\`](/api/${input}/#${formattedLink})`
            description2 = description2.replace(new RegExp(`\`\\b${names}\\b\``, "g"), link);
            description2 = description2.replaceAll("\n", " ");
          }

          mdxContent += `| ${paramName} | ${paramType} | ${description2} |\n`;
        }

        mdxContent += "\n";
        mdxContent += `</div>\n\n`;
      }
      if (func.return.type == 'unsigned int') {
        mdxContent += "**Return Type:** Unsigned Integer\n\n";
      }
      else if (func.return.type != 'void') {
        mdxContent += "**Return Type:** " + typeMappings[func.return.type] + "\n\n";

        mdxContent += "*Returns:* ";
        let returnDescription = func.return.description || "";
        for (const typeName in typeMappings) {
          const typeMapping = typeMappings[typeName];

          returnDescription = returnDescription.replace(
            new RegExp(`\`\\b${typeName}\\b\``, "g"),
            typeMapping
          );
        }

        mdxContent += `${returnDescription}\n\n`;
      }

      mdxContent += "**Signatures:**\n\n";
      mdxContent += "<Tabs syncKey=\"code-language\">\n";

      // Reorder Code tabs
      languageOrder.forEach((lang) => {
        if (func.signatures[lang].length > 0 && func.signatures[lang] != undefined) {
          try {

            const code = (Array.isArray(func.signatures[lang])) ? func.signatures[lang].join("\n") : func.signatures[lang];
            const languageLabel = languageLabelMappings[lang] || lang;
            mdxContent += `  <TabItem label="${languageLabel}">\n`;
            mdxContent +=
              "\n```" + lang + "\n" + code + '\n```\n\n';
            mdxContent += "  </TabItem>\n";
          } catch (e) {
            console.log(e + " " + lang + " " + func.name)
          }
        }
      });

      mdxContent += "</Tabs>\n\n";

      let usageHeading = false;
      let allGuides = [];
      guidesCategories.forEach((category) => {
        category.forEach((guide) => {
          guide.functions.forEach((used) => {
            if (func.unique_global_name == used) {
              allGuides.push({
                name: guide.name,
                url: guide.url
              });
            }
          })
        })
      })

      var limit = 0;
      let allExamples = [];
      examplesCategories.forEach((category) => {
        category.forEach((example) => {
          example.functions.forEach((used) => {
            if (func.unique_global_name == used && limit < 4) {
              allExamples.push({
                name: example.funcKey,
                title: example.title,
                url: example.url
              })
              limit++
            }
          })
        })
      })

      if ((allGuides.length > 0) || (allExamples.length > 0)) {

        if (!usageHeading) {
          mdxContent += "**Usage:&nbsp;&nbsp;&lcub;&lt;/&gt;&rcub;**\n\n";
          usageHeading = true;
        }
        mdxContent += `<Accordion title="See Implementations" uniqueID={${JSON.stringify(func.unique_global_name + "_guides")}} customButton="guidesAccordion">\n\n`

        if (allGuides.length > 0) {
          mdxContent += `**Tutorials and Guides**:\n\n`
          allGuides.forEach((guide) => {
            mdxContent += `- [${guide.name}](${guide.url})\n`
          })
          if (allExamples.length > 0)
            mdxContent += "\n"
        }
        if (allExamples.length > 0) {
          mdxContent += `**API Documentation Code Examples**:\n\n`
          allExamples.forEach((example) => {
            const exampleName = getGroupName(jsonData, example.name);
            mdxContent += `- [${exampleName}](${example.url}): ${example.title}\n`
          })
        }

        mdxContent += `\n`

        mdxContent += `</Accordion>\n\n`
      }

      let linked = false;
      usageExamples.forEach((example) => {
        if (func.unique_global_name == example.split('-')[0]) {
          if (!usageHeading) {
            mdxContent += "**Usage:&nbsp;&nbsp;&lcub;&lt;/&gt;&rcub;**\n\n";
            usageHeading = true;
          }
          mdxContent += getUsageExampleImports(categoryKey, example.replace(".txt", ""));
          if (!linked) {
            // Import code files
            mdxContent += `<Accordion title="See Code Examples" uniqueID={${JSON.stringify(func.unique_global_name + "_example")}} customButton="usageExamplesAccordion">\n\n`;
            linked = true;
          }

          mdxContent += getUsageExampleContent(jsonData, categoryKey, func.name, example);
          mdxContent += `\n`;

        }
      });
      if (linked) {
        mdxContent += `</Accordion>\n`;
        linked = true;
      }

      mdxContent += "---\n"; // Add --- after each function ends

    });
  }
  let allTypes = [];

  allTypes.push(...category.typedefs, ...category.enums, ...category.structs);
  // Remove empty arrays
  allTypes = allTypes.filter((type) => type.name != undefined); // Assuming name property is present

  const sortedTypes = allTypes.sort((a, b) => a.name.localeCompare(b.name));

  if (sortedTypes.length > 0) {
    // Add the Types section
    mdxContent += "\n## Types\n";

    sortedTypes.forEach((type) => {
      if (type.name != undefined) {
        const formattedName = type.name
          .split("_")
          .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
          .join(" ");

        const formattedTypeName = formattedName || `\`${type.name}\``;
        let formattedLinkName = type.name.toLowerCase();
        formattedLinkName = formattedLinkName.replaceAll("_", "-");
        mdxContent += `\n### [${formattedTypeName}](#${formattedLinkName})\n\n`;

        let description = type.description || "";
        for (const typeName in typeMappings) {
          const typeMapping = typeMappings[typeName];
          description = description.replace(new RegExp(`\`\\b${typeName}\\b\``, "g"), typeMapping);
        }

        for (const names of functionNames) {
          const normalName = names
            .split("_")
            .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
            .join(" ");
          const formattedLink = normalName.toLowerCase().replace(/\s+/g, "-");
          const link = `[\`${normalName}\`](/api/${input}/#${formattedLink})`

          description = description.replace(new RegExp(`\`\\b${names}\\b\``, "g"), link);
        }

        // If it's a struct, add a table for its fields
        if (type.fields) {
          mdxContent +=
            "| Field  | Type                                               | Description                                                                        |\n";
          mdxContent +=
            "| ------ | -------------------------------------------------- | ---------------------------------------------------------------------------------- |\n";

          for (const fieldName in type.fields) {
            const field = type.fields[fieldName];
            const fieldType = typeMappings[field.type] || field.type;
            let fieldDescription = field.description || "";

            for (const typeName in typeMappings) {
              const typeMapping = typeMappings[typeName];
              fieldDescription = fieldDescription.replace(
                new RegExp(`\`\\b${typeName}\\b\``, "g"),
                typeMapping
              );
            }
            for (const names of functionNames) {
              const normalName = names
                .split("_")
                .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
                .join(" ");
              const formattedLink = normalName.toLowerCase().replace(/\s+/g, "-");
              const link = `[\`${normalName}\`](/api/${input}/#${formattedLink})`
              description = description.replace(new RegExp(`\`\\b${names}\\b\``, "g"), link);
            }

            mdxContent += `| ${fieldName} | ${fieldType} | ${fieldDescription.replace(/\n/g, '')} |\n`;
          }

          mdxContent += "\n";
        }

        for (const typeName in typeMappings) {
          const typeMapping = typeMappings[typeName];
          description = description.replace(new RegExp(`\`\\b${typeName}\\b\``, "g"), typeMapping);
        }
        for (const names of functionNames) {
          const normalName = names
            .split("_")
            .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
            .join(" ");
          const formattedLink = normalName.toLowerCase().replace(/\s+/g, "-");
          const link = `[\`${normalName}\`](/api/${input}/#${formattedLink})`
          description = description.replace(new RegExp(`\`\\b${names}\\b\``, "g"), link);
        }
        description = description.replaceAll("\n\n\n", "\n\n");
        mdxContent += `${description}\n\n`;

        // If it's an enum, add a table for its constants
        if (type.constants) {
          mdxContent += "<Tabs syncKey=\"code-language\">\n";

          // Build constantsData from type.constants so that they remain the same in all tabs
          const constantsData = {};
          Object.keys(type.constants).forEach((constantName) => {
            const constant = type.constants[constantName];
            constantsData[constantName] = {
              description: constant.description.replace(/\n/g, '') || "No description" // If description is undefined, display "No description"
            };
          });

          // Iterate over each language
          languageOrder.forEach(lang => {
            if (type.signatures[lang]) {
              const signature = Array.isArray(type.signatures[lang]) ? type.signatures[lang].join("\n") : type.signatures[lang];
              const enumValues = extractEnumValues(signature, lang);

              // Build the mapping so that each constant has its own name, but the description remains the same
              const formattedNames = {};
              const cppNames = Object.keys(type.constants);
              cppNames.forEach((cppName, index) => {
                formattedNames[cppName] = enumValues[index] || cppName;
              });

              mdxContent += `  <TabItem label="${languageLabelMappings[lang] || lang}">\n`;
              mdxContent += "| Constant | Description |\n";
              mdxContent += "| --------- | ----------- |\n";

              // Keep the description the same for all constants using the constantsData object
              Object.keys(constantsData).forEach((cppName) => {
                const formattedName = formattedNames[cppName] || cppName;
                const data = constantsData[cppName];
                mdxContent += `| ${formattedName} | ${data.description} |\n`;
              });

              mdxContent += "  </TabItem>\n";
            }
          });

          mdxContent += "</Tabs>\n";
        }

        mdxContent += `\n---\n`;
      }
    });
  }


  // Replace spaces with underscores in the name
  const formattedName = name.replace(/\s+/g, '-');

  // Write the MDX file
  try {
    fs.writeFileSync(`./src/content/docs/api/${formattedName}.mdx`, mdxContent);
    console.log(kleur.yellow('  Generated: ') + kleur.green(`${formattedName}.mdx`));
  } catch (err) {
    success = false;
    console.log(kleur.red(`Error writing ${input} MDX file: ${err.message}`));
    return;
  }
}
// Check if all MDX files generated successfully
if (success) {
  console.log(kleur.green("\nAll API Documentation MDX files generated successfully.\n"));
}
