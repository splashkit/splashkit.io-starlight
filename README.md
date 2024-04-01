# SplashKit SDK - Starlight Framework

## Introduction

Welcome to the official documentation for the SplashKit SDK on the Starlight framework! This README markdown script will guide you through the installation process and provide an overview of the features and functionalities of the SDK.

## Deployment Status

[Thoth Tech's 'splashkit.io' Site](https://splashkit-io.netlify.app/) - [![Netlify Status](https://api.netlify.com/api/v1/badges/e8def4e6-f39d-458a-8ca9-556d61ce1fbd/deploy-status)](https://app.netlify.com/sites/splashkit-io/deploys)

<!-- - [Production](https://master--splashkit.netlify.app/) -   [![Netlify Status](https://api.netlify.com/api/v1/badges/29627b16-8f40-4b42-8ae8-1912895f5305/deploy-status?branch=master)](https://app.netlify.com/sites/splashkit/deploys) ![Github Pages](https://github.com/splashkit/splashkit.io-starlight/actions/workflows/astro.yml/badge.svg?branch=master)
- [Development](https://development--splashkit.netlify.app/) - [![Netlify Status](https://api.netlify.com/api/v1/badges/29627b16-8f40-4b42-8ae8-1912895f5305/deploy-status?branch=development)](https://app.netlify.com/sites/splashkit/deploys) ![Github Pages](https://github.com/splashkit/splashkit.io-starlight/actions/workflows/astro.yml/badge.svg?branch=production) -->

## Installation

1. Install and open Docker app.
2. Fork then clone this repository.
3. Reopen cloned repository in container (pop-up may appear in VS Code)

If needed:

- Install the necessary dependencies. Make sure you have the following installed:

    ```bash
    npm install
    ```

## 🚀 Project Structure

Inside of your Astro + Starlight project, you'll see the following folders and files:

```text
.
├── public/
└── src/
    ├── assets/
    ├── components/
    ├── content/
    │   ├── docs/
    │   │   ├── api/
    │   │   ├── guides/
    │   │   ├── installation/
    │   │   └── troubleshoot/
    ├── fonts/
    ├── styles/
    <!-- ├── config.ts -->
    └── env.d.ts
├── astro.config.mjs
├── package.json
└── tsconfig.json
```

Starlight looks for `.md` or `.mdx` files in the `src/content/docs/` directory. Each file is exposed as a route based on its file name.

Images can be added to `src/assets/` and embedded in Markdown with a relative link.

Static assets, like favicons and gifs, can be placed in the `public/` directory.

## 🧞 Commands

All commands are run from the root of the project, from a terminal:

| Command                   | Action                                           |
| :------------------------ | :----------------------------------------------- |
| `npm install`             | Installs dependencies                            |
| `npm run dev`             | Starts local dev server at `localhost:3000`      |
| `npm run build`           | Build your production site to `./dist/`          |
| `npm run preview`         | Preview your build locally, before deploying     |
| `npm run astro ...`       | Run CLI commands like `astro add`, `astro check` |
| `npm run astro -- --help` | Get help using the Astro CLI                     |
| `npm run generate-mdx`             | Generate MDX file *(for functions)* from JSON data in `test` folder                   |

## Contributing

We welcome contributions from the community to enhance the SplashKit SDK on the Starlight framework. If you would like to contribute, please follow the guidelines outlined in the CONTRIBUTING.md file.
