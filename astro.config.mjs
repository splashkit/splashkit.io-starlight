import { defineConfig } from "astro/config";
import starlight from "@astrojs/starlight";
// import solidJs from "@astrojs/solid-js";
import react from "@astrojs/react";
import starlightLinksValidator from 'starlight-links-validator';
import sitemap from "@astrojs/sitemap";
import remarkMath from 'remark-math';
import rehypeMathjax from 'rehype-mathjax'
// import starlightBlog from 'starlight-blog'
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
        // Temporarily disabled due to virtual module resolution issues
        // starlightBlog({
        //   title: 'Announcements',
        //   recentPostCount: 5,
        //   prevNextLinksOrder: 'chronological',
        // }),
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
          label: "Usage Examples",
          collapsed: false,
          items: [
            { label: "Overview", link: "usage-examples/" },
            { label: "Animations", link: "usage-examples/animations" },
            { label: "Audio", link: "usage-examples/audio" },
            { label: "Camera", link: "usage-examples/camera" },
            { label: "Color", link: "usage-examples/color" },
            { label: "Geometry", link: "usage-examples/geometry" },
            { label: "Graphics", link: "usage-examples/graphics" },
            { label: "Input", link: "usage-examples/input" },
            { label: "Interface", link: "usage-examples/interface" },
            { label: "JSON", link: "usage-examples/json" },
            { label: "Logging", link: "usage-examples/logging" },
            { label: "Networking", link: "usage-examples/networking" },
            { label: "Physics", link: "usage-examples/physics" },
            { label: "Raspberry", link: "usage-examples/raspberry" },
            { label: "Resources", link: "usage-examples/resources" },
            { label: "Resource Bundles", link: "usage-examples/resource_bundles" },
            { label: "Sprites", link: "usage-examples/sprites" },
            { label: "Terminal", link: "usage-examples/terminal" },
            { label: "Timers", link: "usage-examples/timers" },
            { label: "Utilities", link: "usage-examples/utilities" },
            { label: "Windows", link: "usage-examples/windows" },
            { label: "Contributing", link: "usage-examples/contributing" },
          ],
        },
        {
          label: "Tutorials and Guides",
          collapsed: false,
          items: [
            { label: "Overview", link: "guides/" },
            { 
              label: "Getting Started",
              collapsed: false,
              items: [
                { label: "Drawing with Procedures", link: "guides/graphics/drawing-using-procedures" },
                { label: "Understanding Double Buffering", link: "guides/graphics/double-buffering" },
                { label: "Graphical User Inputs", link: "guides/input/user-inputs-in-graphical-applications" },
                { label: "Loading Resources with Bundles", link: "guides/resources/loading-resources-with-bundles" },
                { label: "Getting Started With Audio", link: "guides/audio/getting-started-with-audio" },
                { label: "Using Animations", link: "guides/animations/using-animations" },
                { label: "SplashKit Camera", link: "guides/input/using-splashkit-camera" },
                { label: "Useful Utilities", link: "guides/utilities/useful-utilities" },
                { label: "Using JSON in SplashKit", link: "guides/json/getting-started-with-json" },
                { label: "SplashKit Colors", link: "guides/color/splashkit-colors" },
              ],
            },
            { label: "Raspberry GPIO", autogenerate: { directory: "guides/raspberry-gpio" }, collapsed: true },
            { label: "Physics", autogenerate: { directory: "guides/physics" }, collapsed: true },
            { label: "Interface", autogenerate: { directory: "guides/interface" }, collapsed: true },
            { label: "Networking", autogenerate: { directory: "guides/networking" }, collapsed: true },
            {
              label: "Beyond SplashKit",
              collapsed: true,
              items: [
                { label: "Overview", link: "guides/beyond-splashkit/" },
                { label: "Using SDL2", autogenerate: { directory: "guides/beyond-splashkit/sdl2" }, collapsed: false },
                { label: "Cryptography", autogenerate: { directory: "guides/beyond-splashkit/cryptography" }, collapsed: true },
                { label: "Utilities", autogenerate: { directory: "guides/beyond-splashkit/utilities" }, collapsed: true },
              ],
            },
          ],
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

  // Configure Vite to handle virtual modules
  vite: {
    optimizeDeps: {
      include: ['react', 'react-dom']
    },
    server: {
      hmr: {
        timeout: 120000 // Increase HMR timeout to 2 minutes
      }
    },
    build: {
      chunkSizeWarningLimit: 1000,
      rollupOptions: {
        onwarn(warning, warn) {
          // Suppress certain warnings that might be causing issues
          if (warning.code === 'MODULE_LEVEL_DIRECTIVE') return;
          warn(warning);
        }
      }
    }
  },

  // Render mathematical equations using remark-math and rehype-mathjax
  markdown: {
    remarkPlugins: [remarkMath, remarkHeadingID],
    rehypePlugins: [rehypeMathjax],
  },
});
