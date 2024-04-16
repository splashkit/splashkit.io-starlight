// Author: Aditya Parmar (XQuestCode)
// Contact: thanx.adi@gmail.com
import { defineConfig, squooshImageService } from "astro/config";
import starlight from "@astrojs/starlight";
import solidJs from "@astrojs/solid-js";

import react from "@astrojs/react";

import sitemap from "@astrojs/sitemap";
import starlightLinksValidator from 'starlight-links-validator';

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
      plugins: [starlightLinksValidator()],
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
          autogenerate: { directory: "guides", collapsed: true },
        },
      ],

    }),

    solidJs(), sitemap()
  ],

  // Process images with sharp: https://docs.astro.build/en/guides/assets/#using-sharp
  image: { service: squooshImageService() },
  server: {
    port: 4321
  }
});
