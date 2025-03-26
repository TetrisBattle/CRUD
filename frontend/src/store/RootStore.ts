import { GameStore } from 'feature/game/GameStore'
import { AppStore } from './AppStore'

class RootStore {
	appStore = new AppStore()
	gameStore = new GameStore()
}

export const rootStore = new RootStore()
