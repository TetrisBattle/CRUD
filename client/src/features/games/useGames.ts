import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import agent from 'lib/agent'
import { useLocation } from 'react-router'
import { Game, GameSchema } from 'features/games/gameValidation'

export const useGames = (id?: string) => {
	const queryClient = useQueryClient()
	const location = useLocation()
	const gameQueryKey = 'games'
	const gameApiPath = '/games'

	const { data: games, isPending: isLoadingGames } = useQuery({
		queryKey: [gameQueryKey],
		queryFn: async () => {
			const response = await agent.get<Game[]>(gameApiPath)
			return response.data
		},
		enabled: !id && location.pathname === '/games',
	})

	const { data: game, isPending: isLoadingGame } = useQuery({
		queryKey: [gameQueryKey, id],
		queryFn: async () => {
			const response = await agent.get<Game>(`${gameApiPath}/${id}`)
			return response.data
		},
		enabled: !!id,
	})

	const updateGame = useMutation({
		mutationFn: async (game: Game) => {
			await agent.put(gameApiPath, game)
		},
		onSuccess: async () => {
			await queryClient.invalidateQueries({
				queryKey: [gameQueryKey],
			})
		},
	})

	const createGame = useMutation({
		mutationFn: async (game: GameSchema) => {
			const response = await agent.post(gameApiPath, game)
			return response.data
		},
		onSuccess: async () => {
			await queryClient.invalidateQueries({
				queryKey: [gameQueryKey],
			})
		},
	})

	const deleteGame = useMutation({
		mutationFn: async (id: string) => {
			await agent.delete(`${gameApiPath}/${id}`)
		},
		onSuccess: async () => {
			await queryClient.invalidateQueries({
				queryKey: [gameQueryKey],
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
