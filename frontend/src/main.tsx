import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import { RouterProvider } from 'react-router-dom'
import { MuiThemeProvider } from 'theme/MuiThemeProvider'
import '@fontsource/roboto/300.css'
import '@fontsource/roboto/400.css'
import '@fontsource/roboto/500.css'
import '@fontsource/roboto/700.css'
import { QueryClient, QueryClientProvider } from '@tanstack/react-query'
import { ReactQueryDevtools } from '@tanstack/react-query-devtools'
import { store, StoreContext } from 'lib/Store'
import { router } from 'app/Routes'

createRoot(document.getElementById('root')!).render(
	<StrictMode>
		<StoreContext.Provider value={store}>
			<QueryClientProvider client={new QueryClient()}>
				<ReactQueryDevtools />
				<MuiThemeProvider>
					<RouterProvider router={router} />
				</MuiThemeProvider>
			</QueryClientProvider>
		</StoreContext.Provider>
	</StrictMode>
)
