// Script to generate .mdx file in a specific format to adapt to Starlight from JSON data.

import { readFile, writeFile } from "fs";

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
  animation: "[`Animation`](/components/types/#animation)",
  animation_script: "[`Animation Script`](/components/types/#animation-script)",
  bitmap: "[`Bitmap`](/components/types/#bitmap)",
  circle: "[`Circle`](/components/types/#circle)",
  color: "[`Color`](/components/types/#color)",
  display: "[`Display`](/components/types/#display)",
  drawing_dest: "[`Drawing Dest`](/components/types/#drawing-dest)",
  drawing_options: "[`Drawing Options`](/components/types/#drawing-options)",
  font: "[`Font`](/components/types/#font)",
  font_style: "[`Font Style`](/components/types/#font-style)",
  http_status_code: "[`HTTP Status Code`](/components/types/#http-status-code)",
  line: "[`Line`](/components/types/#line)",
  point_2d: "[`Point 2D`](/components/types/#point-2d)",
  quad: "[`Quad`](/components/types/#quad)",
  rectangle: "[`Rectangle`](/components/types/#rectangle)",
  triangle: "[`Triangle`](/components/types/#triangle)",
  vector_2d: "[`Vector 2D`](/components/types/#vector-2d)",
  database: "[`Database`](/components/database/#database)",
  query_result: "[`Query Result`](/components/database/#query-result)",
  key_callback: "[`Key Callback`](/components/input/#key-callback)",
  key_code: "[`Key Code`](/components/input/#key-code)",
  mouse_button: "[`Mouse Button`](/components/input/#mouse-button)",
  json: "[`JSON`](/components/json/#json)",
  connection: "[`Connection`](/components/networking/#connection)",
  connection_type: "[`Connection Type`](/components/networking/#connection-type)",
  http_method: "[`HTTP Method`](/components/networking/#http-method)",
  http_request: "[`HTTP Request`](/components/networking/#http-request)",
  http_response: "[`HTTP Response`](/components/networking/#http-response)",
  message: "[`Message`](/components/networking/#message)",
  server_socket: "[`Server Socket`](/components/networking/#server-socket)",
  web_server: "[`Web Server`](/components/networking/#web-server)",
  matrix_2d: "[`Matrix 2D`](/components/physics/#matrix-2d)",
  collision_test_kind: "[`Collision Test Kind`](/components/sprites/#collision-test-kind)",
  sprite: "[`Sprite`](/components/sprites/#sprite)",
  sprite_event_handler: "[`Sprite Event Handler`](/components/sprites/#sprite-event-handler)",
  sprite_event_kind: "[`Sprite Event Kind`](/components/sprites/#sprite-event-kind)",
  sprite_float_function: "[`Sprite Float Function`](/components/sprites/#sprite-float-function)",
  sprite_function: "[`Sprite Function`](/components/sprites/#sprite-function)",
  music: "[`Music`](/components/audio/#music)",
  sound_effect: "[`Sound Effect`](/components/audio/#sound-effect)"
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
// Read the JSON file
readFile("./test/api.json", "utf8", (err, data) => {
  if (err) {
    console.error("Error reading JSON file:", err);
    return;
  }

  try {
    const jsonData = JSON.parse(data);

    // Please select an option: "animations, audio, camera, color, database, geometry, graphics, input, json, networking, physics, resource_bundles, resources, social, sprites, terminal, timers, types, utilities, windows"
    for (const categoryKey in jsonData) {
      const category = jsonData[categoryKey];
      let input = categoryKey;
      const categoryFunctions = category.functions;
      let mdxContent = "";
      name = input.split("_")
      .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
      .join(" ");; //name of the category
   
      mdxContent += "---\n";
      mdxContent += `title: ${name}\n`;
      if(category.brief != "") {mdxContent += `description: ${category.brief.replace(/\n/g, '')}\n`;}
      else {mdxContent += `description: Some description....\n`;}
      
      mdxContent += "---\n\n";
      if(category.brief != "") {
      if(categoryFunctions.description != null) {
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
if(guidesAvailable[categoryKey]) {
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
      if (category.typedefs.length > 0) {
        // Add the Types section
        mdxContent += "## Types\n\n";
        category.typedefs.forEach((typedef) => {
          const formattedName3 = typedef.name
            .split("_")
            .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
            .join(" ");

          const formattedTypeName = formattedName3 || `\`${typedef.name}\``;
          mdxContent += `### ${formattedTypeName} [🧾](#${typedef.name.toLowerCase()})\n\n`;

          let description = typedef.description || "";
          for (const typeName in typeMappings) {
            const typeMapping = typeMappings[typeName];
            description = description.replace(new RegExp(`\`\\b${typeName}\\b\``, "g"), typeMapping);
          }
          const functionNames = category.functions.map((func) => func.name);
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
        });
      }


      
      // Write the MDX file
      writeFile(`./src/content/docs/components/${name}.mdx`, mdxContent, (err) => {
        if (err) {
          console.error(`Error writing ${input} MDX file:`, err);
       
        } else {
          console.log(input)
        }

      });
    }
    console.log("MDX files generated successfully: \n");
  } catch (error) {
    console.error("Error parsing JSON:", error);
  }
});

