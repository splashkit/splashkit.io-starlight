// Author: Aditya Parmar (XQuestCode)
// Contact: thanx.adi@gmail.com
import { defineConfig } from "astro/config";
import starlight from "@astrojs/starlight";
import solidJs from "@astrojs/solid-js";


// https://astro.build/config
export default defineConfig({
  site: 'https://splashkit.io/',
// base: '/splashkit.io-starlight',  // if hosted without domain.
//   output: "server",
//   adapter: netlify(),
  integrations: [
    
    starlight({
      title: "SplashKit",
      expressiveCode: {
        // theme: ["github-dark", "github-light"],
        // frames: {
        //   showCopyToClipboardButton: true,
        // },
        styleOverrides: { borderRadius: '0.5rem' },
        useDarkModeMediaQuery: true,
      },
      customCss: [
        "/src/styles/tailwind.docs.css",
        "/src/styles/custom.css",
        "/src/styles/background.css",
        "/src/styles/cards.css",
      ],
      social: {
        github: "https://github.com/splashkit",
        facebook: "http://facebook.com/splashkit",
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
          label: "Components",
          autogenerate: { directory: "api", collapsed: false },
        },
        {
          label: "Guides",
          collapsed: true,
          autogenerate: { directory: "guides", collapsed: true },
        },
        {
          label: "Troubleshooting",
          // items: [
          // 	// Each item here is one entry in the navigation menu.
          // 	{ label: 'MacOS', link: '/troubleshoot/macos/mac/' },
          // 	//{ label: 'Windows', link: '/troubleshoot/macOS/mac' },
          // ],
          collapsed: false,
          autogenerate: { directory: "troubleshoot", collapsed: true },
          badge: "New",
        },
      ],
    }),
    solidJs(),
  ],

  // Process images with sharp: https://docs.astro.build/en/guides/assets/#using-sharp
  image: { service: { entrypoint: "astro/assets/services/sharp" } },
});
