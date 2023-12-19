const fs = require('fs').promises;
const path = require('path');
const kleur = require('kleur');

const apiPath = path.join(__dirname, '..', 'src', 'content', 'docs', 'api');
const guidePath = path.join(__dirname, '..', 'src', 'content', 'docs', 'guides');
async function deleteComponents(folderPath) {
    try {
      const files = await fs.readdir(folderPath);
  
      for (const file of files) {
        const filePath = path.join(folderPath, file);
        const extname = path.extname(filePath);
  
        if (extname === '.mdx') {
          await fs.unlink(filePath);
          console.log(kleur.red(`Deleted: ${filePath}`));
        }
      }
  
      console.log(kleur.green('Deleted all .mdx files in the api folder.'));
    } catch (error) {
      console.error(kleur.red(`Error deleting .mdx files: ${error.message}`));
    }
}


// Recursive function to delete all index.mdx files in a folder and its subfolders
async function deleteGuides(folderPath) {
  try {
    const files = await fs.readdir(folderPath);

    for (const file of files) {
      const filePath = path.join(folderPath, file);
      const isDirectory = (await fs.stat(filePath)).isDirectory();

      if (isDirectory) {
        // Recursively call the function for subfolders
        await deleteGuides(filePath);
      } else {
        const extname = path.extname(filePath);

        if (extname === '.mdx' && file.toLowerCase() === 'index.mdx') {
          // Delete the index.mdx file
          await fs.unlink(filePath);
          console.log(kleur.green(`Deleted: ${filePath}`));
        }
      }
    }
  } catch (error) {
    console.error(kleur.red(`Error deleting Guide index files: ${error.message}`));
  }
}

// Specify the root folder path
const rootPath = path.join(__dirname, '..', 'src', 'content', 'docs', 'guides');

// Call the function to delete index.mdx files
deleteComponents(apiPath);
deleteGuides(guidePath);
