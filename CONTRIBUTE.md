# Contribution Guide

Follow these steps to contribute to the SplashKit website repository:

1. **Fork the Repository:**

   - Visit the SplashKit repository on GitHub.
   - Click on the "Fork" button in the top-right corner of the page. This will create a copy of the repository under your GitHub account.

2. **Clone Your Fork:**

   - Open your terminal or Git client.
   - Clone your forked repository to your local machine using the following command:

    ```shell
    git clone https://github.com/YOUR_USERNAME/splashkit.git
    ```

3. **Checkout new branch:**

   - Open your terminal or Git client.
   - Create a new branch on your forked repository using the following command (replace `<new-branch>` with your chosen name):

    ```shell
    git checkout -b ＜new-branch＞
    ```

4. **Make Your Changes:**

   - Navigate to the project directory on your local machine.
   - Make your respective changes, ensuring high-quality contributions.

5. **Commit Your Changes:**

   - After making changes, commit them with meaningful commit messages.

    ```shell
    git add .
    git commit -m "Your descriptive commit message"
    ```

6. **Push Changes to Your Fork:**

   - Push your changes to your forked repository on GitHub.

    ```shell
    git push origin master
    ```

7. **Create a Pull Request (PR):**

   - Visit your forked repository on GitHub.
   - Click on the "New Pull Request" button.
   - Ensure the base and head repositories have been set correctly.
   - Click on "Create Pull Request."

8. **Wait for Review:**

   - The maintainers will review your PR. Be patient, and be ready to respond to any feedback or comments.
   - If changes are requested, make the necessary updates and push them to your forked repository.

9. **Follow Up to Comments:**

   - Engage with any comments or questions from the maintainers.
   - If additional changes are needed, repeat steps 4-7.

10. **PR Approval/Rejection:**

    - Once your changes are approved, the maintainers will merge your PR into the main repository.
    - If your changes are rejected, understand the feedback and consider making improvements before submitting another PR.

By following these steps, you contribute effectively to the SplashKit website. Remember to adhere to the project's guidelines and maintain a collaborative and respectful environment.

## Website Guide

This guide provides information on the structure and organization of the SplashKit website, which is built on the Starlight framework. Follow these instructions to navigate through the project and make necessary updates effectively.

### Installation and Commands

For detailed installation instructions and common commands, refer to the [`README.md`](/README.md) file in the root directory of the project.

### Project Structure Overview

The SplashKit website project structure is organized as follows:

```plaintext
.
├── public/               # Publicly accessible resources
│   ├── gifs/                 # GIF files used across the website
│   ├── images/               # General image resources
│   ├── resources/            # Resource files for various purposes
│   └── usage-examples/       # Files for usage examples
├── src/
│   ├── assets/               # Additional assets for the website
│   ├── components/           # Reusable UI components
│   ├── content/              # Documentation and content files
│   │   ├── docs/                 # Main documentation directory
│   │   ├── guides/               # Guides for specific features
│   │   ├── installation/         # Installation instructions
│   │   ├── troubleshoot/         # Troubleshooting information
│   ├── fonts/                # Custom fonts used on the site
│   ├── styles/               # Global and component CSS styles
└── test/                 # Scripts for testing and page generation
```

### Image and Usage Example Resources

All image resources are located in the `public/images` directory.

Usage examples, which illustrate how to use different SplashKit functions, are organized under the `public/usage-examples/` directory. Ensure that any new usage example files are placed here.

### Documentation Pages

Documentation pages are stored under `src/content/docs/`. For sections related to specific components, such as Animations, Sounds, or other SplashKit features, refer to the respective subdirectories within `src/content/docs/components`.

- Each section may include an `index.mdx` file, which serves as the main page when navigating to a section URL (e.g., the `index.mdx` file in the `installation` folder is accessed via `https://your-site/installation/`).

### Styling and CSS Files

All CSS files can be found under the `src/styles/` directory. If you add new CSS files or directories, ensure they are referenced in the `astro.config.mjs` file in the root directory to apply styles correctly across the website.

### Test Directory

The `test` directory contains scripts, including a NodeJS script that generates MDX pages needed for component generation. Refer to comments within each script for specific instructions on usage and customization.

### Guidelines

Adhere to these structure and organization guidelines to maintain a functional, well-organized SplashKit website on the Starlight framework. Consistency across directories and files will streamline contributions and enhance project maintainability.
