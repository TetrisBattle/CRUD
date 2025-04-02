import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import agent from '../../lib/agent'
import { useLocation } from 'react-router'
import { Game, GameSchema } from 'features/games/gameValidation'

export const useGames = (id?: string) => {
	const queryClient = useQueryClient()
	const location = useLocation()

	const { data: games, isPending: isLoadingGames } = useQuery({
		queryKey: ['games'],
		queryFn: async () => {
			const response = await agent.get<Game[]>('/games')
			return response.data
		},
		enabled: !id && location.pathname === '/games',
	})

	const { data: game, isPending: isLoadingGame } = useQuery({
		queryKey: ['games', id],
		queryFn: async () => {
			const response = await agent.get<Game>(`/games/${id}`)
			return response.data
		},
		enabled: !!id,
	})

	const updateGame = useMutation({
		mutationFn: async (game: Game) => {
			await agent.put('/games', game)
		},
		onSuccess: async () => {
			await queryClient.invalidateQueries({
				queryKey: ['games'],
			})
		},
	})

	const createGame = useMutation({
		mutationFn: async (game: GameSchema) => {
			const response = await agent.post('/games', game)
			return response.data
		},
		onSuccess: async () => {
			await queryClient.invalidateQueries({
				queryKey: ['games'],
			})
		},
	})

	const deleteGame = useMutation({
		mutationFn: async (id: string) => {
			await agent.delete(`/games/${id}`)
		},
		onSuccess: async () => {
			await queryClient.invalidateQueries({
				queryKey: ['games'],
			})
		},
	})

	return {
		games,
		isLoadingGames,
		game,
		isLoadingGame,
		updateGame,
		createGame,
		deleteGame,
	}
}
