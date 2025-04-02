import { Box, Button } from '@mui/material'
import { useNavigate } from 'react-router-dom'

export const Home = () => {
	const navigate = useNavigate()

	return (
		<Box sx={{ p: 2, display: 'flex', gap: 2 }}>
			<Button onClick={() => navigate('/games')}>Games</Button>
		</Box>
	)
}
