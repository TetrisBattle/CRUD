import { Box, Button, Typography } from '@mui/material'

export const Home = () => {
	return (
		<Box sx={{ p: 2 }}>
			<Typography variant='h1'>Home</Typography>

			<Box sx={{ display: 'flex', gap: 1 }}>
				<Button>Primary</Button>
				<Button color='secondary'>Secondary</Button>
			</Box>
		</Box>
	)
}
