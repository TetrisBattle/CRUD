import { Box, Button } from '@mui/material'
import { useNavigate } from 'react-router-dom'
import { callHelloApi } from './game/GameGateway'

export const Home = () => {
	const navigate = useNavigate()

	return (
		<Box sx={{ p: 2 }}>
			<Button onClick={() => navigate('/newGame')}>Add new game</Button>
			<Button
				onClick={() =>
					callHelloApi()
						.then((message) =>
							console.log('API Response:', message)
						)
						.catch((error) => console.error('Failed:', error))
				}
			>
				test
			</Button>
		</Box>
	)
}
