import { App } from 'app/App'
import { GameForm } from 'features/games/GameForm'
import { Games } from 'features/games/Games'
import { Home } from 'features/Home'
import { createBrowserRouter } from 'react-router'

export const router = createBrowserRouter([
	{
		path: '/',
		element: <App />,
		children: [
			{ path: '/', element: <Home /> },
			{ path: 'games', element: <Games /> },
			// { path: 'games/:id', element: <Game /> },
			{ path: 'games/new', element: <GameForm key='new' /> },
			{ path: 'games/:id/edit', element: <GameForm key='edit' /> },
		],
	},
])
