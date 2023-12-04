const fs = require('fs').promises;
const path = require('path');
const yaml = require('js-yaml');
const spinners = require('cli-spinners');
const kleur = require('kleur');

const rootPath = path.join(__dirname, '..', 'src', 'content', 'docs', 'guides');

try {
  async function processFolder(folderPath, topLevelFolderName = '') {
    const folders = folderPath.split(path.sep);
      const lastTwoFolders = folders.slice(-2);
    const spinner = createSpinner(`Processing ${lastTwoFolders.join(' -> ')}`);

    try {
      const files = await fs.readdir(folderPath);
      const linkCards = [];

      for (const file of files) {
        const filePath = path.join(folderPath, file);
        const isDirectory = (await fs.stat(filePath)).isDirectory();

        if (isDirectory) {
          const subfolderName = path.basename(filePath);

          // Recursive call to process subfolder
          await processFolder(filePath, `${topLevelFolderName ? `${topLevelFolderName}/` : ''}${subfolderName}`);

          // Add LinkCard for subfolder
          linkCards.push(
            `<LinkCard
              title="${subfolderName} Guides"
              description="Examples & Guides"
              href="/guides/${topLevelFolderName ? `${topLevelFolderName.toLowerCase()}/` : ''}${subfolderName.toLowerCase()}/"
            />`
          );
        } else {
          const extname = path.extname(filePath);

          if (extname === '.md' || extname === '.mdx') {
            if (file !== 'index.mdx') {
              const fileContent = await fs.readFile(filePath, 'utf-8');
              const frontmatter = extractFrontmatter(fileContent, filePath);

              const author = frontmatter.author || 'Various';
              const lastupdated = frontmatter.lastupdated ? `on ${frontmatter.lastupdated}` : '';

              // Convert title to lowercase and replace spaces with '-'
              const folderTitle = path.relative(rootPath, folderPath).split(path.sep).join('/').toLowerCase();

              // Convert file name to lowercase and replace spaces with '-'
              const fileName = file.replace(/\.mdx?$/, '').toLowerCase().replace(/ /g, '-');

              linkCards.push(
                `<LinkCard
                  title="${frontmatter.title || fileName}"
                  description="Written by ${author} ${lastupdated}"
                  href="/guides/${folderTitle}/${fileName}/"
                />`
              );
            }
          }
        }
      }

      const indexMdxContent = generateIndexMdxContent(linkCards);
      const indexFilePath = path.join(folderPath, 'index.mdx');

      await fs.writeFile(indexFilePath, indexMdxContent);
      const folders = indexFilePath.split(path.sep);
      const lastTwoFolders = folders.slice(-2);
  
      spinner.succeed(kleur.green(`Generated ${lastTwoFolders.join(' -> ')}`));
    } catch (error) {
      const folders = folderPath.split(path.sep);
      const lastTwoFolders = folders.slice(-2);
  
     
      spinner.fail(kleur.red(`Error processing ${lastTwoFolders.join(' -> ')}: ${error.message}`));
    }
  }

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
  

  function extractFrontmatter(content, filePath) {
    const frontmatterRegex = /^---\n([\s\S]+?)\n---/;
    const match = content.match(frontmatterRegex);

    if (match && match[1]) {
      const frontmatterString = match[1];

      try {
        const frontmatter = yaml.load(frontmatterString);

        // Ensure that the frontmatter is an object
        if (frontmatter && typeof frontmatter === 'object') {
          return frontmatter;
        } else {
          console.error(`Invalid frontmatter in file: ${filePath}`);
        }
      } catch (error) {
        console.error(`Error parsing frontmatter in file: ${filePath}`);
      }
    }

    return {};
  }

  function generateIndexMdxContent(linkCards) {
    return `---
title: Index Routing Page
sidebar:
  hidden: true
---

import { LinkCard, CardGrid } from "@astrojs/starlight/components";

<CardGrid stagger>
  ${linkCards.join('\n  ')}
</CardGrid>
`;
  }

  processFolder(rootPath);
} catch (error) {
  console.log(error);
}