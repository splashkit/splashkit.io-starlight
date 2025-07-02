import { defineConfig } from "astro/config";
import starlight from "@astrojs/starlight";
// import solidJs from "@astrojs/solid-js";
import react from "@astrojs/react";
import starlightLinksValidator from 'starlight-links-validator';
import sitemap from "@astrojs/sitemap";
import remarkMath from 'remark-math';
import rehypeMathjax from 'rehype-mathjax'
import starlightBlog from 'starlight-blog'
import starlightDocSearch from '@astrojs/starlight-docsearch';
import remarkHeadingID from 'remark-heading-id';
import { loadEnv } from "vite";

const { DOCSEARCH_API_ID } = loadEnv(process.env.DOCSEARCH_API_ID, process.cwd(), "");
const { DOCSEARCH_API_SEARCH_KEY } = loadEnv(process.env.DOCSEARCH_API_SEARCH_KEY, process.cwd(), "");
const { DOCSEARCH_INDEX_NAME } = loadEnv(process.env.DOCSEARCH_INDEX_NAME, process.cwd(), "");

if (!DOCSEARCH_API_ID || !DOCSEARCH_API_SEARCH_KEY || !DOCSEARCH_INDEX_NAME) {
  console.error("Algolia DocSearch enviroment variables are invalid. Please check configuration!");
  process.exit(1);
}

// https://astro.build/config
export default defineConfig({
  site: 'https://splashkit.io/',
  integrations: [
    starlight({
      title: "SplashKit",
      description: 'SplashKit is a cross-platform game engine for C, C++ and Objective-C. It provides a simple API for 2D game development.',
      plugins: [
        starlightBlog({
          title: 'Announcements',
          recentPostCount: 5,
          prevNextLinksOrder: 'chronological',
        }),
        starlightLinksValidator({
          errorOnRelativeLinks: true,
        }),
        starlightDocSearch({
          appId: DOCSEARCH_API_ID,
          apiKey: DOCSEARCH_API_SEARCH_KEY,
          indexName: DOCSEARCH_INDEX_NAME,
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
      social: [
        { icon: 'github', label: 'GitHub', href: 'https://github.com/splashkit' },
        { icon: 'youtube', label: 'YouTube', href: 'https://www.youtube.com/@splashkit7674' },
      ],
      favicon: "/images/favicon.svg",
      logo: {
        src: "./src/assets/favicon.svg",
      },
      sidebar: [
        {
          label: "Installation",
          collapsed: false,
          items: [
            { label: "Installation Overview", link: "installation/" },
            {
              label: "Windows",
              collapsed: true,
              items:
                [
                  { label: "MSYS2", autogenerate: { directory: "installation/Windows (MSYS2)" }, collapsed: false },
                  { label: "WSL", autogenerate: { directory: "installation/Windows (WSL)" }, collapsed: false },
                ]
            },
            { label: "MacOS", autogenerate: { directory: "installation/MacOS" }, collapsed: true },
            { label: "Linux", autogenerate: { directory: "installation/Linux" }, collapsed: true },
            { label: "Virtual Machine", autogenerate: { directory: "installation/Virtual Machine" }, collapsed: true },
          ],
        },
        {
          label: "Troubleshooting",
          collapsed: true,
          items: [
            { label: "Troubleshooting Overview", link: "troubleshoot/" },
            {
              label: "Windows",
              collapsed: true,
              items:
                [
                  { label: "MSYS2", autogenerate: { directory: "troubleshoot/Windows (MSYS2)" }, collapsed: false },
                  { label: "WSL", autogenerate: { directory: "troubleshoot/Windows (WSL)" }, collapsed: false },
                ]
            },
            { label: "MacOS", autogenerate: { directory: "troubleshoot/MacOS" }, collapsed: true },
            { label: "Linux", autogenerate: { directory: "troubleshoot/Linux" }, collapsed: true },
          ],
          // autogenerate: { directory: "troubleshoot", collapsed: true },
        },
        {
          label: "API Documentation",
          autogenerate: { directory: "api", collapsed: false },
        },
        {
          label: "Tutorials and Guides",
          collapsed: false,
          items: [
            { label: "Overview", link: "guides/" },
            { label: "Getting Started", autogenerate: { directory: "guides/getting-started" }, collapsed: false },
            { label: "Raspberry GPIO", autogenerate: { directory: "guides/raspberry-gpio" }, collapsed: true },
            { label: "Physics", autogenerate: { directory: "guides/physics" }, collapsed: true },
            { label: "Interface", autogenerate: { directory: "guides/interface" }, collapsed: true },
            { label: "Networking", autogenerate: { directory: "guides/networking" }, collapsed: true },
          ],
          // autogenerate: { directory: "guides", collapsed: true },
        },
        {
          label: "Beyond SplashKit",
          collapsed: false,
          items: [
            { label: "Overview", link: "beyond-splashkit/" },
            { label: "Using SDL2", autogenerate: { directory: "beyond-splashkit/getting-started-with-sdl" }, collapsed: false },
            { label: "Cryptography", autogenerate: { directory: "beyond-splashkit/cryptography" }, collapsed: true },
            { label: "Utilities", autogenerate: { directory: "beyond-splashkit/utilities" }, collapsed: true },
          ],
          // autogenerate: { directory: "beyond-splashkit", collapsed: true },
        },
      ],

    }),

    react(),
    sitemap()
  ],

  server: {
    host: true,
    port: 4321
  },

  // Render mathematical equations using remark-math and rehype-mathjax
  markdown: {
    remarkPlugins: [remarkMath, remarkHeadingID],
    rehypePlugins: [rehypeMathjax],
  },
});
