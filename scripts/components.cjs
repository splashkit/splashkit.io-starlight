// Script to generate .mdx file in a specific format to adapt to Starlight from JSON data.
const fs = require("fs");
const kleur = require("kleur");
const spinners = require('cli-spinners');


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
  animations: true,
  audio: true,
  camera: true,
  database: true,
  inputs: true,
  json: true,
  networking: true,
  sprites: true,
  utilities: true

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




function Mappings(jsonData) {
  //generate mappings from API
  for (const categoryKey in jsonData) {
    const category = jsonData[categoryKey];
    category.typedefs.forEach((typedef) => {
      // Add typedef to typeMappings
      const name = typedef.name.split("_")
        .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
        .join(" ");
      
      typeMappings[typedef.name] = `[\`${name}\`](/components/${categoryKey.toLowerCase().replace(/\s+/g, "-")}/#${name.toLowerCase().replace(/\s+/g, "-")})`;
    });
    category.structs.forEach((struct) => {
      // Add structs to typeMappings
      const name = struct.name.split("_")
        .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
        .join(" ");
      
      typeMappings[struct.name] = `[\`${name}\`](/components/${categoryKey.toLowerCase().replace(/\s+/g, "-")}/#${name.toLowerCase().replace(/\s+/g, "-")})`;
    });
    category.enums.forEach((enumm) => {
      // Add structs to typeMappings
      const name = enumm.name.split("_")
        .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
        .join(" ");
      
      typeMappings[enumm.name] = `[\`${name}\`](/components/${categoryKey.toLowerCase().replace(/\s+/g, "-")}/#${name.toLowerCase().replace(/\s+/g, "-")})`;
    });
  }
}
fs.readFile(`${__dirname}/api.json`, "utf8", (err, data) => {
  if (err) {
    console.error(kleur.red("Error reading JSON file:"), err);
    console.error("Error reading JSON file:", err);
    return;
  }

  try {
    const jsonData = JSON.parse(data);
    Mappings(jsonData);
    const spinner = createSpinner(`Generating MDX files for components`);
    
  


    // Please select an option: "animations, audio, camera, color, database, geometry, graphics, input, json, networking, physics, resource_bundles, resources, social, sprites, terminal, timers, types, utilities, windows"
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
      mdxContent += `\nimport { Tabs, TabItem } from "@astrojs/starlight/components";\nimport { LinkCard, CardGrid } from "@astrojs/starlight/components";
\n    `;
      if (guidesAvailable[categoryKey]) {
        mdxContent += "\n## \n";
        mdxContent += "## Animations Guides\n";
        mdxContent += `<LinkCard
          title="Using ${name}"
          description="Examples & Guides"
          href="/guides/${input}/"
        />\n\n`;
      }
      mdxContent += "## \n";
      mdxContent += "## Functions\n";
      mdxContent += "## \n";
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

          const formattedGroupLink = `group-${formattedLink}`;
          mdxContent += `## ${formattedFunctionName} [📁](#${formattedGroupLink})\n\n`;
          mdxContent += ":::note\n\n";
          mdxContent += "This function is overloaded. The following versions exist:\n\n";

          overloads.forEach((func, index) => {
            mdxContent += `- [**${formattedFunctionName}** (`;
            for (const paramName in func.parameters) {
              const param = func.parameters[paramName];
              const paramType = param.type;
              if (index > 0) {
                mdxContent += "";
              }
              mdxContent += `${paramName}: ${paramType}, `;
            }
            mdxContent += `)](/components/${input}/#${formattedLink.toLowerCase()}--${index + 1})\n`;
          });

          mdxContent += "\n:::\n\n";
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
            ? `### ${functionName2} [📄](#${formattedLink.toLowerCase()}--${index + 1})`
            : `## ${functionName2} [🔗](#${formattedLink})\n\n`;


          // Replace type names in the description with formatted versions
          let description = func.description || "";
          for (const typeName in typeMappings) {
            const typeMapping = typeMappings[typeName];
            description = description.replace(
              new RegExp(`\`\\b${typeName}\\b\``, "g"),
              typeMapping
            );
          }

          mdxContent += `${formattedName} \n`;
          for (const names of functionNames) {
            const normalName = names
              .split("_")
              .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
              .join(" ");
            const formattedLink = normalName.toLowerCase().replace(/\s+/g, "-");
            const link = `[\`${normalName}\`](/components/${input}/${formattedLink})`
            description = description.replace(new RegExp(`\`\\b${names}\\b\``, "g"), link);
          }
          mdxContent += description ? `${description}\n\n` : "";
          mdxContent += "**Return Type**\n\n- " + typeMappings[func.return.type] + " \n\n";

          // Add Parameters section only if there are parameters
          if (Object.keys(func.parameters).length > 0) {
            mdxContent += "**Parameters**\n\n";
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
                const link = `[\`${normalName}\`](/components/${input}/${formattedLink})`
                description2 = description2.replace(new RegExp(`\`\\b${names}\\b\``, "g"), link);
              }

              mdxContent += `| ${paramName} | ${paramType} | ${description2} |\n`;
            }

            mdxContent += "\n";
          }

          mdxContent += "**Signatures**\n\n";
          mdxContent += "<Tabs>\n";

          // Reorder Code tabs
          languageOrder.forEach((lang) => {
            if (func.signatures[lang]) {
              const code = func.signatures[lang].join("\n");
              const languageLabel = languageLabelMappings[lang] || lang;
              mdxContent += `  <TabItem label="${languageLabel}">\n`;
              mdxContent +=
                "```" + lang + "\n" + code + '\n```\n';
              mdxContent += "  </TabItem>\n";
            }
          });

          mdxContent += "</Tabs>\n\n";
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
        mdxContent += "## Types\n\n";

        sortedTypes.forEach((type) => {
          if(type.name != undefined) {
          const formattedName = type.name
            .split("_")
            .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
            .join(" ");

          const formattedTypeName = formattedName || `\`${type.name}\``;
          mdxContent += `### ${formattedTypeName} [🧾](#${type.name.toLowerCase()})\n\n`;

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
            const link = `[\`${normalName}\`](/components/${input}/${formattedLink})`
            description = description.replace(new RegExp(`\`\\b${names}\\b\``, "g"), link);
          }


          mdxContent += `${description}\n\n`;
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
                const link = `[\`${normalName}\`](/components/${input}/${formattedLink})`
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
            const link = `[\`${normalName}\`](/components/${input}/${formattedLink})`
            description = description.replace(new RegExp(`\`\\b${names}\\b\``, "g"), link);
          }
          
          mdxContent += `${description}\n\n`;
          mdxContent += `---\n`;
      }});
      }
   
 


      // Write the MDX file
      fs.writeFile(`./src/content/docs/components/${name}.mdx`, mdxContent, (err) => {
        if (err) {
          spinner.fail(kleur.red(`Error writing ${input} MDX file: ${err.message}`));
         
        } else {
          
          spinner.succeed(kleur.yellow('Generated')+kleur.green(` -> ${input}`));
  
        }

      });

    }
    console.log(kleur.green("All component MDX files generated successfully.\n"));
    function createSpinner(text) {
      const spinner = spinners.dots;
    
      process.stdout.write(`${text}... `);
    
      const interval = setInterval(() => {
        if (process.stdout.clearLine) {
          process.stdout.clearLine();
          process.stdout.cursorTo(0);
        }
        process.stdout.write(kleur.cyan(spinner.frame()));
      }, spinner.interval);
    
      return {
        succeed: (message) => {
          clearInterval(interval);
          if (process.stdout.clearLine) {
            process.stdout.clearLine();
            process.stdout.cursorTo(0);
          }
          console.log(kleur.green(`${message} ✔`));
        },
        fail: (message) => {
          clearInterval(interval);
          if (process.stdout.clearLine) {
            process.stdout.clearLine();
            process.stdout.cursorTo(0);
          }
          console.log(kleur.red(`${message} ✘`));
        },
      };
    }
    
    
  } catch (error) {
    console.error(kleur.red("Error parsing JSON:"), error);
  }
});

