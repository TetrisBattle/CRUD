import { createContext } from 'react'
import { AppStore } from '../app/AppStore'

export const store = {
	appStore: new AppStore(),
}

export const StoreContext = createContext(store)
