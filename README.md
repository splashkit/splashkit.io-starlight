# [splashkit.io](https://splashkit.io) Website - Starlight Framework

<img width="150px" align="right" src="https://github.com/thoth-tech/.github/blob/main/images/splashkit.png" alt="SplashKit Logo"/>

Welcome to the official documentation website for the SplashKit SDK, using the Starlight (Astro) framework! This README will guide you through the installation process and provide an overview of the features and functionalities of the SDK.

[splashkit/splashkit.io-starlight](https://github.com/splashkit/splashkit.io-starlight)

[![GitHub contributors](https://img.shields.io/github/contributors/splashkit/splashkit.io-starlight?label=Contributors&color=F5A623)](https://github.com/splashkit/splashkit.io-starlight/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/splashkit/splashkit.io-starlight?label=Issues&color=F5A623)](https://github.com/splashkit/splashkit.io-starlight/issues)
[![GitHub pull requests](https://img.shields.io/github/issues-pr/splashkit/splashkit.io-starlight?label=Pull%20Requests&color=F5A623)](https://github.com/splashkit/splashkit.io-starlight/pulls)
[![Website](https://img.shields.io/website?down_color=red&down_message=offline&label=Website&up_color=green&up_message=online&url=https%3A%2F%2Fsplashkit.io)](https://splashkit.io/)
![Netlify](https://img.shields.io/netlify/29627b16-8f40-4b42-8ae8-1912895f5305?label=Netlify&color=F5A623)
![Forks](https://img.shields.io/github/forks/splashkit/splashkit.io-starlight?label=Forks&color=F5A623)
![Stars](https://img.shields.io/github/stars/splashkit/splashkit.io-starlight?label=Stars&color=F5A623)

[thoth-tech/splashkit.io-starlight](https://github.com/thoth-tech/splashkit.io-starlight) *

[![GitHub contributors](https://img.shields.io/github/contributors/thoth-tech/splashkit.io-starlight?label=Contributors&color=F5A623)](https://github.com/thoth-tech/splashkit.io-starlight/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/thoth-tech/splashkit.io-starlight?label=Issues&color=F5A623)](https://github.com/thoth-tech/splashkit.io-starlight/issues)
[![GitHub pull requests](https://img.shields.io/github/issues-pr/thoth-tech/splashkit.io-starlight?label=Pull%20Requests&color=F5A623)](https://github.com/thoth-tech/splashkit.io-starlight/pulls)
[![Website Preview](https://img.shields.io/badge/Preview-splashkit.io-blue)](https://splashkit-io.netlify.app/)
![Forks](https://img.shields.io/github/forks/thoth-tech/splashkit.io-starlight?label=Forks&color=F5A623)
![Stars](https://img.shields.io/github/stars/thoth-tech/splashkit.io-starlight?label=Stars&color=F5A623)

**\* SplashKit Development in Thoth Tech**

Thoth Tech is a people-focused educational technology company within Deakin University's capstone program which provides real-world learning opportunities and allows students to contribute significantly to projects like SplashKit, enhancing its capabilities and resources.

## Installation

If needed:

1. Install and open Docker: Ensure Docker is installed and running on your machine.
2. Fork and clone this repository: This allows you to make your own changes and submit them if needed.
3. Reopen the cloned repository in a container: You may get a prompt to open it in a container in VS Code; select "Reopen in Container."

- Install the necessary dependencies. Make sure you have the following installed:

    ```shell
    npm install
    ```

## 🚀 Project Structure

Inside of your Astro + Starlight project, you'll see the following folders and files:

```plaintext
.
├── public/
│   ├── gifs/
│   ├── images/
│   ├── resources/
│   └── usage-examples/
├── scripts/
└── src/
    ├── assets/
    ├── components/
    ├── content/
    │   ├── docs/
    │   │   ├── api/
    │   │   ├── guides/
    │   │   ├── installation/
    │   │   ├── troubleshoot/
    │   │   └── arcade-hackathon-project/
    ├── fonts/
    ├── styles/
    <!-- ├── config.ts -->
    └── env.d.ts
├── astro.config.mjs
├── package.json
└── tsconfig.json
```

- **Documentation Files**: Starlight looks for `.md` or `.mdx` files in the `src/content/docs/` directory. Each file is exposed as a route based on its file name.
- **Images and Assets**: Images can be added to `src/assets/` and embedded in Markdown with a relative link.
- **Static Assets**: Static assets, like favicons and gifs, can be placed in the `public/` directory.

## 🧞 Commands

All commands are run from the root of the project, from a terminal:

| Command                                 | Action                                                                                                      |
| :-------------------------------------- | :---------------------------------------------------------------------------------------------------------- |
| `npm install`                           | Installs dependencies                                                                                       |
| `npm run dev`                           | Starts local dev server at `localhost:4322`                                                                 |
| `npm run build`                         | Builds your production site to `./dist/`                                                                    |
| `npm run preview`                       | Previews your build locally, before deploying                                                               |
| `npm run astro ...`                     | Runs CLI commands like `astro add`, `astro check`                                                           |
| `npm run astro -- --help`               | Gets help using the Astro CLI                                                                               |
| `npm run generate-mdx`                  | Generates an MDX file *(for functions)* from JSON data in the `test` folder                                 |
| `npm run generate-usage-examples-pages` | Runs the script to generate usage example pages from the `./scripts/usage-example-page-generation.cjs` file |
| `npm run generate-usage-examples-pages write_line-1-simple` | Runs the script to generate usage example pages from the `./scripts/usage-example-page-generation.cjs` file and prints the testing output for the `write_line-1-simple` example |
| `npm run check-links`                   | Sets `CHECK_LINKS=true`, runs `npm run build`, then resets `CHECK_LINKS=false`                              |

## Contributing

We welcome contributions from the community to enhance the SplashKit SDK on the Starlight framework. If you would like to contribute, please follow the guidelines outlined in the [CONTRIBUTE.md](./CONTRIBUTE.md) file.
