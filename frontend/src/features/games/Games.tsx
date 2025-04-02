import {
	Box,
	Card,
	CardActionArea,
	CardHeader,
	IconButton,
	LinearProgress,
} from '@mui/material'
import { useGames } from './useGames'
import {
	Add as AddIcon,
	Edit as EditIcon,
	Delete as DeleteIcon,
} from '@mui/icons-material'
import { useNavigate } from 'react-router-dom'

export const Games = () => {
	const { games = [], isLoadingGames, deleteGame } = useGames()
	const navigate = useNavigate()

	if (isLoadingGames) return <LinearProgress />

	return (
		<Box sx={{ p: 2, display: 'flex', flexDirection: 'column', gap: 1 }}>
			<Card sx={{ width: 140, position: 'relative' }}>
				<CardActionArea onClick={() => navigate('/games/new')}>
					<CardHeader title={'New Game'} />
					<AddIcon
						sx={{
							position: 'absolute',
							top: 16,
							right: 8,
						}}
					/>
				</CardActionArea>
			</Card>
			{games.map((game) => (
				<Card key={game.id} sx={{ width: 300, position: 'relative' }}>
					<CardActionArea>
						<CardHeader title={game.name} />
					</CardActionArea>
					<Box
						sx={{
							position: 'absolute',
							top: 8,
							right: 8,
						}}
					>
						<IconButton
							aria-label='edit'
							color='primary'
							onClick={() => navigate(`/games/${game.id}/edit`)}
						>
							<EditIcon />
						</IconButton>
						<IconButton
							aria-label='delete'
							color='error'
							onClick={() => deleteGame.mutate(game.id)}
						>
							<DeleteIcon />
						</IconButton>
					</Box>
				</Card>
			))}
		</Box>
	)
}
