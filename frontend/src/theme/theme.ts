import { createTheme, ThemeOptions } from '@mui/material'
import { defaultTheme } from './defaultTheme'
import { deepmerge } from '@mui/utils'

const customTheme: ThemeOptions = {
	palette: {
		mode: 'dark',
		primary: {
			main: '#1E90FF',
		},
		secondary: {
			main: '#008080',
		},
		text: {
			primary: '#E0E0E0',
			secondary: '#A0A0A0',
		},
	},
}

export const theme = createTheme(deepmerge(defaultTheme, customTheme))
