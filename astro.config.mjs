import { defineConfig, squooshImageService } from "astro/config";
import starlight from "@astrojs/starlight";
import solidJs from "@astrojs/solid-js";
import react from "@astrojs/react";
import starlightLinksValidator from 'starlight-links-validator';
import sitemap from "@astrojs/sitemap";

// https://astro.build/config
export default defineConfig({
  site: 'https://splashkit.io/',
  // base: '/splashkit.io-starlight',  // if hosted without domain.
  //   output: "server",
  //   adapter: netlify(),
  integrations: [
    starlight({
      title: "SplashKit",
      description: 'SplashKit is a cross-platform game engine for C, C++ and Objective-C. It provides a simple API for 2D game development.',
      components: {
        Sidebar: './src/components/Sidebar.astro'
      },

      plugins: [
        starlightLinksValidator({
          errorOnRelativeLinks: true,
        }),
      ],
      expressiveCode: {
        // theme: ["github-dark", "github-light"],
        // frames: {
        //   showCopyToClipboardButton: true,
        // },
        styleOverrides: { borderRadius: '0.5rem' },
        useDarkModeMediaQuery: true,
      },
      customCss: [

        "/src/styles/custom.css",
        "/src/styles/background.css",
        "/src/styles/cards.css",
      ],
      social: {
        github: "https://github.com/splashkit",
        youtube: 'https://www.youtube.com/@splashkit7674'
      },
      favicon: "/images/favicon.svg",
      logo: {
        src: "./src/assets/favicon.svg",
      },
      sidebar: [
        {
          label: "Installation",
          collapsed: true,
          autogenerate: { directory: "installation", collapsed: true },
          // items: [
          //   { label: "Linux", autogenerate: { directory: "linux", collapsed: true }, attrs: { class: 'linux' } },
          //   { label: "MacOS", autogenerate: { directory: "macos", collapsed: true }, attrs: { class: 'macos' } },
          //   { label: "Windows", autogenerate: { directory: "windows", collapsed: true }, attrs: { class: 'windows' } },
          // ]
        },
        {
          label: "Troubleshooting",
          // items: [
          // 	// Each item here is one entry in the navigation menu.
          // 	{ label: 'MacOS', link: '/troubleshoot/macos/mac/' },
          // 	//{ label: 'Windows', link: '/troubleshoot/macOS/mac' },
          // ],
          collapsed: true,
          autogenerate: { directory: "troubleshoot", collapsed: true },
          badge: "New",

        },
        {
          label: "Developer Documentation",
          autogenerate: { directory: "api", collapsed: false },
        },
        {
          label: "Tutorials and Guides",
          collapsed: true,
          items: [
            { label: "Using SplashKit", autogenerate: { directory: "guides/0-using-splashkit", collapsed: false } },
            { label: "Animations", autogenerate: { directory: "guides/animations", collapsed: false } },
            { label: "Audio", autogenerate: { directory: "guides/audio", collapsed: false } },
            { label: "Camera", autogenerate: { directory: "guides/camera", collapsed: false } },
            { label: "Graphics", autogenerate: { directory: "guides/graphics", collapsed: false } },
            { label: "Input", autogenerate: { directory: "guides/input", collapsed: false } },
            { label: "Interface", autogenerate: { directory: "guides/interface", collapsed: false } },
            { label: "Json", autogenerate: { directory: "guides/json", collapsed: false } },
            { label: "Networking", autogenerate: { directory: "guides/networking", collapsed: false } },
            { label: "Raspberry GPIO", autogenerate: { directory: "guides/raspberry", collapsed: false } },
            { label: "Resource Bundles", autogenerate: { directory: "guides/resource_bundles", collapsed: false } },
            { label: "Sprites", autogenerate: { directory: "guides/sprites", collapsed: false } },
            { label: "Utilities", autogenerate: { directory: "guides/utilities", collapsed: false } },
          ]
          // autogenerate: { directory: "guides", collapsed: true },
        },
        {
          label: "Usage Examples",
          autogenerate: { directory: "usage-examples", collapsed: true },
        },
        {
          label: "Arcade Hackathon Project",
          autogenerate: { directory: "arcade-hackathon-project", collapsed: true },
        },
      ],

    }),

    solidJs(), sitemap()
  ],

  // Process images with sharp: https://docs.astro.build/en/guides/assets/#using-sharp
  image: { service: squooshImageService() },
  server: {
    host: true,
    port: 4321
  }
});
