import { defineConfig } from "astro/config";
import starlight from "@astrojs/starlight";
import solidJs from "@astrojs/solid-js";
import expressiveCode from "astro-expressive-code";
// import netlify from "@astrojs/netlify/functions";

// https://astro.build/config
export default defineConfig({
  // site: '',
//   output: "server",
//   adapter: netlify(),
  integrations: [
    expressiveCode({
      theme: ["github-dark", "github-light"],
      frames: {
        showCopyToClipboardButton: true,
      },
    }),
    starlight({
      title: "SplashKit",
      customCss: [
        "/src/styles/tailwind.docs.css",
        "/src/styles/custom.css",
        "/src/styles/background.css",
        "/src/styles/cards.css",
      ],
      social: {
        github: "https://github.com/splashkit",
        twitter: "http://twitter.com/splashkit",
      },
      favicon: "/images/favicon.svg",
      logo: {
        src: "./src/assets/favicon.svg",
      },
      sidebar: [
        {
          label: "Installation",

          autogenerate: { directory: "installation", collapsed: true },
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
          label: "Components",
          autogenerate: { directory: "components", collapsed: true },
        },
        {
          label: "Guides",
          collapsed: true,
          autogenerate: { directory: "guides", collapsed: true },
        },
      ],
    }),
    solidJs(),
  ],

  // Process images with sharp: https://docs.astro.build/en/guides/assets/#using-sharp
  image: { service: { entrypoint: "astro/assets/services/sharp" } },
});
