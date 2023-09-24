import { defineConfig } from 'astro/config';
import starlight from '@astrojs/starlight';
import solidJs from "@astrojs/solid-js";
import expressiveCode from "astro-expressive-code";


// https://astro.build/config
export default defineConfig({
	// site: '',

	integrations: [
		expressiveCode({
			theme: ['github-dark', 'github-light'],
			frames: {
			  showCopyToClipboardButton: true,
			},
		  }),
		starlight({
			title: 'Splashkit',
			customCss: ['/src/styles/tailwind.docs.css', '/src/styles/custom.css','/src/styles/background.css', '/src/styles/cards.css'],
			social: {
				github: 'https://github.com/splashkit',
				twitter: 'http://twitter.com/splashkit',
			},
			favicon: '/public/images/favicon.svg',
			logo: {
				src: './src/assets/favicon.svg',
			  },
			sidebar: [ 
				{
					label: 'Installation',
				
					autogenerate: { directory: 'installation', collapsed: true, },
				},
				{
					label: 'Components',
					autogenerate: { directory: 'components', collapsed: false, },
				},
				{
					label: 'Guides',
					collapsed: true,
					autogenerate: { directory: 'guides', collapsed: true, },
				},
				{
					label: 'Troubleshooting',
					// items: [
					// 	// Each item here is one entry in the navigation menu.
					// 	{ label: 'MacOS', link: '/troubleshoot/macos/mac/' },
					// 	//{ label: 'Windows', link: '/troubleshoot/macOS/mac' },
					// ],
					collapsed: false,
					autogenerate: { directory: 'troubleshoot', collapsed: true, },
					badge: 'New'
				},
				
			],
		}), solidJs()
	],

	// Process images with sharp: https://docs.astro.build/en/guides/assets/#using-sharp
	image: { service: { entrypoint: 'astro/assets/services/sharp' } },
});
