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
			logo: {
				src: './src/assets/favicon.svg',
			  },
			sidebar: [ 
				{
					label: 'Installation',
					items: [
						// Each item here is one entry in the navigation menu.
						{ label: 'Example Guide', link: '/guides/example/' },
					],
				},
				{
					label: 'Troubleshooting',
					// items: [
					// 	// Each item here is one entry in the navigation menu.
					// 	{ label: 'MacOS', link: '/troubleshoot/macos/mac/' },
					// 	//{ label: 'Windows', link: '/troubleshoot/macOS/mac' },
					// ],
					autogenerate: { directory: 'troubleshoot', collapsed: true, },
				},
				
			],
		}),
	],

	// Process images with sharp: https://docs.astro.build/en/guides/assets/#using-sharp
	image: { service: { entrypoint: 'astro/assets/services/sharp' } },
});
