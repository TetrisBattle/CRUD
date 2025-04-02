import { useContext } from 'react'
import { StoreContext } from './Store'

export const useStore = () => {
	return useContext(StoreContext)
}
