import { Box, Button } from '@mui/material'
import { useNavigate } from 'react-router-dom'

export const Home = () => {
	const navigate = useNavigate()

	return (
		<Box sx={{ p: 2 }}>
			<Button onClick={() => navigate('/newGame')}>Add new game</Button>
		</Box>
	)
}
