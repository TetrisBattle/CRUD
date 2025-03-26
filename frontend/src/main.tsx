import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import { RouterProvider } from 'react-router-dom'
import { router } from 'App'
import { StoreProvider } from 'store/StoreProvider'
import { MuiThemeProvider } from 'theme/MuiThemeProvider'

createRoot(document.getElementById('root')!).render(
	<StrictMode>
		<StoreProvider>
			<MuiThemeProvider>
				<RouterProvider router={router} />
			</MuiThemeProvider>
		</StoreProvider>
	</StrictMode>
)
