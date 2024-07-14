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

3. **Make Your Changes:**
   - Navigate to the project directory on your local machine.
   - Make your respective changes, ensuring high-quality contributions.

4. **Commit Your Changes:**
   - After making changes, commit them with meaningful commit messages.

     ```shell
     git add .
     git commit -m "Your descriptive commit message"
     ```

5. **Push Changes to Your Fork:**
   - Push your changes to your forked repository on GitHub.

     ```shell
     git push origin master
     ```

6. **Create a Pull Request (PR):**
   - Visit your forked repository on GitHub.
   - Click on the "New Pull Request" button.
   - Ensure the base repository is set to `splashkit/splashkit` and the base branch is `main`.
   - Ensure the head repository is set to `YOUR_USERNAME/splashkit` and the compare branch is `master`.
   - Click on "Create Pull Request."

7. **Wait for Review:**
   - The maintainers will review your PR. Be patient, and be ready to respond to any feedback or comments.
   - If changes are requested, make the necessary updates and push them to your forked repository.

8. **Follow Up to Comments:**
   - Engage with any comments or questions from the maintainers.
   - If additional changes are needed, repeat steps 4-7.

9. **PR Approval/Rejection:**
   - Once your changes are approved, the maintainers will merge your PR into the main repository.
   - If your changes are rejected, understand the feedback and consider making improvements before submitting another PR.

By following these steps, you contribute effectively to the SplashKit website. Remember to adhere to the project's guidelines and maintain a collaborative and respectful environment.

## Website Guide

<!-- TODO: Update the information below -->

This guide provides information on the structure and organization of the SplashKit website using the Starlight framework. Follow these instructions to navigate through the project and make necessary updates.

### Installation and Commands

For basic installation and commands, please refer to the [`Readme.md`](/README.md) file in the project's root directory.

### Image Resources

All image resources are located under the `public` root directory.

### Documentation Pages

Documentation pages are stored under `root/src/content/docs/`. To find information on specific SplashKit components such as Animations, Sounds, etc., refer to the respective sections within the `components` directory.

Each working directory can contain an `index.mdx` file. This file serves as the page that will be accessed when only the section is fetched. For instance, under the `installation` directory, the `index.mdx` page will be accessed when `https://some-host/installation/` is fetched.

### CSS Files

CSS files can be found under `src/styles/`. If you create a new directory or use new style files, update the `astro.config.mjs` file in the root directory to read the files.

### Test Directory

Inside the `test` directory, you will find a NodeJS script that generates MDX pages required for component generation. Refer to the comments inside the script for detailed instructions on usage and customization.

Make sure to follow these guidelines to maintain a well-organized and functional SplashKit website powered by the Starlight framework.
