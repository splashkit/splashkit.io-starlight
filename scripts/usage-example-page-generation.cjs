// 

const fs = require("fs");
const kleur = require("kleur");
const path = require('path');


// Define language label mappings
const languageLabelMappings = {
  cpp: "C++",
  csharp: "C#",
  // python: "Python",
  // pascal: "Pascal",
  // Add more mappings as needed
};

const languageOrder = ["cpp", "csharp"];//, "python", "pascal"];

var name;

function getJsonData() {
  var data = fs.readFileSync(`${__dirname}/api.json`);
  return JSON.parse(data);
}

function getApiCategories(jsonData) {
  const apiCategories = [];
  for (const categoryKey in jsonData) {
    if (categoryKey != "types") {
      apiCategories.push(categoryKey);
    }
  }
  return apiCategories;
}

function getUniqueFunctionNames(categoryKey, jsonData) {
  const category = jsonData[categoryKey];
  const functionNames = category.functions.map((func) => func.unique_global_name);
  return functionNames;
}

function getFunctionGroups(categoryKey, jsonData) {
  const category = jsonData[categoryKey];
  const functionNames = category.functions.map((func) => func.name);
  return functionNames;
}

function getAllFiles(dir, allFilesList = []) {
  const files = fs.readdirSync(dir);
  files.map(file => {
    const name = dir + '/' + file;
    if (fs.statSync(name).isDirectory()) { // check if subdirectory is present
      getAllFiles(name, allFilesList);     // do recursive execution for subdirectory
    } else {
      allFilesList.push(file);           // push filename into the array
    }
  })
  return allFilesList;
}

function getFunctionLink(jsonData, groupNameToCheck, uniqueNameToCheck) {
  var isOverloaded;
  var functionIndex = -1;
  var functionLink = "";
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

console.log(`Generating MDX files for usage-examples`);
let apiJsonData = getJsonData();
let categories = getApiCategories(apiJsonData);

categories.forEach((categoryKey) => {
  let categoryPath = './src/assets/usage-examples-code/' + categoryKey;
  const categoryFiles = getAllFiles(categoryPath);
  const txtFiles = categoryFiles.filter(file => file.endsWith('.txt'))

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
    mdxContent += "banner:\n";
    mdxContent += `  content: Check out how to use the ${categoryTitle} functions!\n`;
    mdxContent += "---\n\n";
    mdxContent += ":::note\n";
    mdxContent += `This page contains code examples of the [${categoryTitle}](/api/${categoryURL}) functions.\n`
    mdxContent += ":::\n\n";

    mdxContent += `import { Tabs, TabItem } from "@astrojs/starlight/components";\n`
    mdxContent += `import { Code } from '@astrojs/starlight/components';\n`;
    mdxContent += `import Signatures from "/src/components/Signatures.astro";\n`;

    // get function overload info
    let functionGroups = getFunctionGroups(categoryKey, apiJsonData);

    // get function info
    let functions = getUniqueFunctionNames(categoryKey, apiJsonData);
    let functionIndex = 0;
    var groupName = "";
    functions.forEach((functionKey) => {
      const functionExampleFiles = txtFiles.filter(file => file.startsWith(functionKey + '-'));
      groupName = functionGroups[functionIndex];

      if (functionExampleFiles.length > 0) {

        // Create function heading
        let functionTitle = groupName.split("_")
          .map((word) => word.charAt(0).toUpperCase() + word.slice(1))
          .join(" ");

        // Create Function Example heading with link
        const functionURL = getFunctionLink(apiJsonData, groupName, functionKey);
        mdxContent += `\n## [${functionTitle}](/api/${categoryURL}/#${functionURL.replaceAll("_", "-")}) Examples*\n\n`;

        // Function signature heading (possible need to update)
        const signature = apiJsonData[categoryKey].functions.map((func) => func.signature)[functionIndex].replaceAll(";", "");
        mdxContent += `:::tip[*]\n`;
        mdxContent += `The example(s) below are using the **${functionTitle}** function with the following signatures:\n\n`
        mdxContent += `<Signatures name="${functionKey.replaceAll("_", "-")}">\n`;
        mdxContent += `</Signatures>\n`;
        mdxContent += "\n:::\n";

        functionExampleFiles.forEach((exampleTxtKey) => {
          let exampleKey = exampleTxtKey.replaceAll(".txt", "");

          // Description
          let txtFilePath = './src/assets/usage-examples-code/' + categoryKey + "/" + functionKey + "/" + exampleTxtKey;
          let exampleTxt = fs.readFileSync(txtFilePath);
          mdxContent += "\n";
          mdxContent += exampleTxt.toString();
          mdxContent += "\n\n";

          // import code
          let codePath = './src/assets/usage-examples-code/' + categoryKey + "/" + functionKey;
          const codeFiles = getAllFiles(codePath);
          let importTitle = exampleKey.replaceAll("-", "_");
          // C++ file
          const cppFiles = codeFiles.filter(file => file.endsWith('.cpp'));
          let cppFilePath = '/src/assets/usage-examples-code/' + categoryKey + "/" + functionKey + "/" + exampleTxtKey.replaceAll(".txt", ".cpp");
          if (cppFiles.length > 0) {
            mdxContent += `import ${importTitle}_cpp from '${cppFilePath}?raw';\n`;
          }
          // C# file
          const csharpFiles = codeFiles.filter(file => file.endsWith('.cs'));
          let csharpFilePath = '/src/assets/usage-examples-code/' + categoryKey + "/" + functionKey + "/" + exampleTxtKey.replaceAll(".txt", ".cs");
          if (csharpFiles.length > 0) {
            mdxContent += `import ${importTitle}_csharp from '${csharpFilePath}?raw';\n`;
          }
          // Add python and pascal

          mdxContent += "\n";

          // Code tabs
          mdxContent += "<Tabs syncKey=\"code-language\">\n";
          languageOrder.forEach((lang) => {

            if (cppFiles.length > 0) {
              const languageLabel = languageLabelMappings[lang] || lang;
              mdxContent += `  <TabItem label="${languageLabel}">\n`;
              let cppFilePath = './src/assets/usage-examples-code/' + categoryKey + "/" + functionKey + "/" + exampleTxtKey.replaceAll(".txt", ".cpp");
              mdxContent += `    <Code code={${importTitle}_${lang}} lang="${lang}" />\n`;
              mdxContent += "  </TabItem>\n";
            }
          });
          mdxContent += "</Tabs>\n\n";

          // Image or gif output
          mdxContent += "**Output**:\n\n";

          const outputFiles = getAllFiles('./public/usage-examples-images-gifs/' + categoryKey);
          const imageFiles = outputFiles.filter(file => file.endsWith(exampleKey + '.png'));
          let outputFilePath;
          if (imageFiles.length > 0) {
            outputFilePath = '/usage-examples-images-gifs/' + categoryKey + "/" + exampleTxtKey.replaceAll(".txt", ".png");
          }
          else {
            const gifFiles = outputFiles.filter(file => file.endsWith('.gif'));
            if (gifFiles.length > 0) {
              outputFilePath = '/usage-examples-images-gifs/' + categoryKey + "/" + exampleTxtKey.replaceAll(".txt", ".gif");
            }
            else {
              console.log("No image or gif files found for " + exampleKey + "usage example");
            }
          }

          mdxContent += `![${exampleKey} example](${outputFilePath})\n`
          mdxContent += "\n---\n";
        });
      }
      functionIndex++;
    });

    // Write the MDX file
    fs.writeFile(`./src/content/docs/usage-examples/${name}.mdx`, mdxContent, (err) => {
      if (err) {
        console.log(kleur.red(`Error writing ${categoryKey} MDX file: ${err.message}`));
      } else {
        console.log(kleur.yellow('Usage Examples') + kleur.green(` -> ${categoryKey}`));

      }
    });
  }
});
console.log(kleur.green("All usage-example MDX files generated successfully.\n"));