import { createBrowserRouter, Navigate, Outlet } from 'react-router-dom'
import { NotFound } from 'feature/NotFound'
import { Home } from 'feature/Home'

const getPages = () => {
	const pages = [
		{ path: '/404', element: <NotFound /> },
		{ path: '/', element: <Home /> },
	]

	if (!import.meta.env.DEV) {
		pages.push({
			path: '*',
			element: <Navigate replace to='/404' />,
		})
	}

	return pages
}

export const router = createBrowserRouter([
	{
		path: '/',
		element: <Outlet />,
		children: getPages(),
	},
])
