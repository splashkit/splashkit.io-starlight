import { defineConfig, squooshImageService } from "astro/config";
import starlight from "@astrojs/starlight";
import solidJs from "@astrojs/solid-js";
import react from "@astrojs/react";
import starlightLinksValidator from 'starlight-links-validator';
import sitemap from "@astrojs/sitemap";
import remarkMath from 'remark-math';
import rehypeMathjax from 'rehype-mathjax'
import starlightBlog from 'starlight-blog'

// https://astro.build/config
export default defineConfig({
  site: 'https://splashkit.io/',
  integrations: [
    starlight({
      title: "SplashKit",
      description: 'SplashKit is a cross-platform game engine for C, C++ and Objective-C. It provides a simple API for 2D game development.',
      plugins: [
        starlightBlog({
          title: 'SplashKit Blog',
          recentPostCount: 5,
          prevNextLinksOrder: 'chronological',
        }),
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
          label: "Blog",
          autogenerate: { directory: "blog", collapsed: true },
        },
        {
          label: "Installation",
          collapsed: true,
          autogenerate: { directory: "installation", collapsed: true },
        },
        {
          label: "Troubleshooting",
          collapsed: true,
          autogenerate: { directory: "troubleshoot", collapsed: true },
        },
        {
          label: "Developer API Documentation",
          autogenerate: { directory: "api", collapsed: false },
        },
        {
          label: "Tutorials and Guides",
          collapsed: true,
          items: [
            { label: "Overview", link: "guides/" },
            { label: "Using SplashKit", autogenerate: { directory: "guides/Using-SplashKit", collapsed: false } },
            { label: "Animations", autogenerate: { directory: "guides/Animations", collapsed: false } },
            { label: "Audio", autogenerate: { directory: "guides/Audio", collapsed: false } },
            { label: "Camera", autogenerate: { directory: "guides/Camera", collapsed: false } },
            { label: "Color", autogenerate: { directory: "guides/Color", collapsed: false } },
            { label: "Graphics", autogenerate: { directory: "guides/Graphics", collapsed: false } },
            { label: "Input", autogenerate: { directory: "guides/Input", collapsed: false } },
            { label: "Interface", autogenerate: { directory: "guides/Interface", collapsed: false } },
            { label: "Json", autogenerate: { directory: "guides/JSON", collapsed: false } },
            { label: "Networking", autogenerate: { directory: "guides/Networking", collapsed: false } },
            { label: "Physics", badge: 'New', autogenerate: { directory: "guides/Physics", collapsed: false } },
            { label: "Raspberry GPIO", autogenerate: { directory: "guides/Raspberry-GPIO", collapsed: false } },
            { label: "Resource Bundles", autogenerate: { directory: "guides/Resource-Bundles", collapsed: false } },
            { label: "Utilities", autogenerate: { directory: "guides/Utilities", collapsed: false } },
          ],
          // autogenerate: { directory: "guides", collapsed: true },
        },
        {
          label: "Usage Examples",
          autogenerate: { directory: "usage-examples", collapsed: true },
          badge: "New",
        },
        {
          label: "Beyond SplashKit",
          autogenerate: { directory: "beyond-splashkit", collapsed: true },
          badge: "New",
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
  },

  // Render mathematical equations using remark-math and rehype-mathjax
  markdown: {
    remarkPlugins: [remarkMath],
    rehypePlugins: [rehypeMathjax],
  },
});
