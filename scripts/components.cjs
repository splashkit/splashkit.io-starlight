// Script to generate .mdx file in a specific format to adapt to Starlight from JSON data.

// Author: @XQuestCode and @omckeon
const fs = require("fs");
const kleur = require("kleur");
const path = require('path');

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


// Define language order
const languageOrder = ["cpp", "csharp", "python", "pascal"];
var name = "";

const sk_colors = ["alice_blue", "antique_white", "aqua", "aquamarine", "azure", "beige", "bisque", "black", "blanched_almond", "blue", "blue_violet", "bright_green", "brown", "burly_wood", "cadet_blue", "chartreuse", "chocolate", "coral", "cornflower_blue", "cornsilk", "crimson", "cyan", "dark_blue", "dark_cyan", "dark_goldenrod", "dark_gray", "dark_green", "dark_khaki", "dark_magenta", "dark_olive_green", "dark_orange", "dark_orchid", "dark_red", "dark_salmon", "dark_sea_green", "dark_slate_blue", "dark_slate_gray", "dark_turquoise", "dark_violet", "deep_pink", "deep_sky_blue", "dim_gray", "dodger_blue", "firebrick", "floral_white", "forest_green", "fuchsia", "gainsboro", "ghost_white", "gold", "goldenrod", "gray", "green", "green_yellow", "honeydew", "hot_pink", "indian_red", "indigo", "ivory", "khaki", "lavender", "lavender_blush", "lawn_green", "lemon_chiffon", "light_blue", "light_coral", "light_cyan", "light_goldenrod_yellow", "light_gray", "light_green", "light_pink", "light_salmon", "light_sea_green", "light_sky_blue", "light_slate_gray", "light_steel_blue", "light_yellow", "lime", "lime_green", "linen", "magenta", "maroon", "medium_aquamarine", "medium_blue", "medium_orchid", "medium_purple", "medium_sea_green", "medium_slate_blue", "medium_spring_green", "medium_turquoise", "medium_violet_red", "midnight_blue", "mint_cream", "misty_rose", "moccasin", "navajo_white", "navy", "old_lace", "olive", "olive_drab", "orange", "orange_red", "orchid", "pale_goldenrod", "pale_green", "pale_turquoise", "pale_violet_red", "papaya_whip", "peach_puff", "peru", "pink", "plum", "powder_blue", "purple", "red", "rosy_brown", "royal_blue", "saddle_brown", "salmon", "sandy_brown", "sea_green", "sea_shell", "sienna", "silver", "sky_blue", "slate_blue", "slate_gray", "snow", "spring_green", "steel_blue", "swinburne_red", "tan", "teal", "thistle", "tomato", "transparent", "turquoise", "violet", "wheat", "white", "white_smoke", "yellow", "yellow_green"];

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

function getAllFinishedExamples() {
  var apiJsonData;
  try {
    var apiData = fs.readFileSync(`${__dirname}/api.json`);
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
    //let categoryFilePath = './public/usage-examples/' + categoryKey;
    const categoryFilePath = path.join(path.dirname(__dirname), "public", "usage-examples", categoryKey);
    const categoryFiles = getAllFiles(categoryFilePath);

    // Filter for .txt files
    const txtFiles = categoryFiles.filter(file => file.endsWith('.txt'));

    // Extract the portion before the first '-'
    if (txtFiles.length > 0) {
      txtFiles.forEach((file) => {
        const filename = file.split('-')[0];
        allExamples.push(filename);
      });
    }
  });

  return allExamples;
}

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

function getColorData() {
  var data = fs.readFileSync(`${__dirname}/colors.json`);
  return JSON.parse(data);
}

function getColorRGBValues(colorName, jsonData) {
  const simplifiedName = colorName.replace("color_", "");

  const colorData = jsonData[simplifiedName];
  let rgbValues = '( 0, 0, 0)';
  if (colorData != undefined) {
    rgbValues = colorData.rgb;
  }
  return rgbValues;
}

function getJsonData() {
  var jsonFile;
  var jsonData;
  try {
    jsonFile = fs.readFileSync(`${__dirname}/guides.json`);
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

function getApiCategories(jsonData) {
  const apiCategories = [];
  for (const categoryKey in jsonData) {
    if (categoryKey != "types") {
      apiCategories.push(jsonData[categoryKey]);
    }
  }
  return apiCategories;
}

// Clean directory function to remove all files except those in the exclusions list
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

console.log('Cleaning up directory for Api Documentation pages...\n');
cleanDirectory(directoryToClean, filesToKeep);

const readGuides = require('./api-guides-generation.cjs');

fs.readFile(`${__dirname}/api.json`, "utf8", async (err, data) => {
  if (err) {
    console.error(kleur.red("Error reading JSON file:"), err);
    console.error("Error reading JSON file:", err);
    return;
  }
  
  try {
    const jsonData = JSON.parse(data);
    Mappings(jsonData);
    console.log(`\nGenerating MDX files for components\n`);

    const guidesDir = path.join(__dirname, 'guides'); // Base directory for guides
    const outputFile = path.join(__dirname, 'guides.json')

    try {
      // console.log(kleur.green('Reading guides folder...'));
      const guidesContent = readGuides(guidesDir);

      try {
        console.log(kleur.green('Writing guides functions to json file...\n'));
        fs.writeFileSync(outputFile, JSON.stringify(guidesContent, null, 4));
      } catch (err) {
        console.log(kleur.red('Error writing output files: ', err));
      }
    } catch (error) {
      console.log(kleur.red('Error processing guides files: ', error));
    }

    const jsonColors = getColorData();
    let guidesJson = getJsonData();
    let guidesCategories = getApiCategories(guidesJson);

    const usageExamples = getAllFinishedExamples();
    // console.log(usageExamples);

    // Please select an option: "animations, audio, camera, color, database, geometry, graphics, input, json, networking, physics, resource_bundles, resources, social, sprites, terminal, timers, types, utilities, windows"
    for (const categoryKey in jsonData) {
      const category = jsonData[categoryKey];
      // console.log(categoryKey);
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
      mdxContent += `\nimport { Tabs, TabItem, LinkCard, CardGrid, LinkButton } from "@astrojs/starlight/components";\nimport Accordion from '../../../components/Accordion.astro'\n`;
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

        if (isOverloaded) {
          // Create a section for overloaded functions

          const formattedFunctionName = functionName
            .split("_")
            .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
            .join(" ");
          const formattedLink = formattedFunctionName.toLowerCase().replace(/\s+/g, "-");

          const formattedGroupLink = `${formattedLink}`;
          mdxContent += `\n### [${formattedFunctionName}](#${formattedGroupLink})\n\n`;

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
            mdxContent += `)](/api/${input}/#${formattedLink.toLowerCase()}-${index + 1})\n`;
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

          const formattedName = isOverloaded
            ? `\n#### [${functionName2}](#${formattedLink.toLowerCase()}-${index + 1})`
            : `\n### [${functionName2}](#${formattedLink})`;


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
            mdxContent +=
              "| Name   | Type                                               | Description                                                                        |\n";
            mdxContent +=
              "| ------ | -------------------------------------------------- | ---------------------------------------------------------------------------------- |\n";

            for (const paramName in func.parameters) {
              const param = func.parameters[paramName];
              const paramType = typeMappings[param.type] || param.type;
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
          }
          if (func.return.type == 'unsigned int') {
            mdxContent += "**Return Type:** Unsigned Integer\n\n";
          }
          else if (func.return.type != 'void') {
            mdxContent += "**Return Type:** " + typeMappings[func.return.type] + "\n\n";
          }

          let usageHeading = false;

          let linked = false;
          usageExamples.forEach((example) => {
            if (func.unique_global_name == example && !linked) {
              formattedUsageLink = func.unique_global_name.replace(/_/g, "-");

              mdxContent += `**Usage:**\n\n`
              usageHeading = true;

              mdxContent += `<LinkButton href="/usage-examples/${categoryKey}/#${formattedUsageLink}" variant="secondary">\nSee Example Code\n</LinkButton>\n\n`
              linked = true;
            }
          });

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

          if (allGuides.length > 0) {

            if (!usageHeading) {
              mdxContent += "**Usage:**\n\n"
            }
            mdxContent += `<Accordion title="See Implemenations in Guides" uniqueID={${JSON.stringify(func.unique_global_name)}} customButton="guidesAccordion">\n\n`

            mdxContent += `<ul>`
            allGuides.forEach((guide) => {
              mdxContent += `<li> [${guide.name}](${guide.url}) </li>`
            })
            mdxContent += `</ul>\n\n`

            mdxContent += `</Accordion>\n`
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

          mdxContent += "</Tabs>\n";
          mdxContent += "\n---\n"; // Add --- after each function ends

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


            // mdxContent += `${description}\n\n`;
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

            // If it's an enum, add a table for its constants
            if (type.constants) {
              mdxContent +=
                "| Constant           | Value | Description                |\n";
              mdxContent +=
                "| ------------------- | ----- | -------------------------- |\n";

              for (const constantName in type.constants) {
                const constant = type.constants[constantName];
                const constantValue = constant.number !== undefined ? constant.number : "";
                const constantDescription = constant.description || "";

                mdxContent += `| ${constantName} | ${constantValue} | ${constantDescription.replace(/\n/g, '')} |\n`;
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
            mdxContent += `---\n`;
          }
        });
      }


      // Replace spaces with hyphens in the name
      const formattedName = name.replace(/\s+/g, '-');

      // Write the MDX file
      fs.writeFile(`./src/content/docs/api/${formattedName}.mdx`, mdxContent, (err) => {
        if (err) {
          console.log(kleur.red(`Error writing ${input} MDX file: ${err.message}`));
        } else {

          console.log(kleur.yellow('API Documentation') + kleur.green(` -> ${input}`));
        }
      });

    }
    console.log(kleur.green("All component MDX files generated successfully.\n"));
  } catch (error) {
    console.error(kleur.red("Error parsing JSON:"), error);
  }
});