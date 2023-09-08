import { defineConfig } from 'astro/config';
import starlight from '@astrojs/starlight';

// https://astro.build/config
export default defineConfig({
	integrations: [
		starlight({
			title: 'Splashkit',
			social: {
				github: 'https://github.com/splashkit',
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
					// items: [
					// 	// Each item here is one entry in the navigation menu.
					// 	{ label: 'Example Guide', link: '/guides/example/' },
					// 	{ label: 'Aman', link: '/guides/abc/' },
					// ],
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
		}),
	],

	// Process images with sharp: https://docs.astro.build/en/guides/assets/#using-sharp
	image: { service: { entrypoint: 'astro/assets/services/sharp' } },
});
