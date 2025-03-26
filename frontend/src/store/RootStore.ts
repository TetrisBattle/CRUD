import { AppStore } from './AppStore'

class RootStore {
	appStore = new AppStore()
}

export const rootStore = new RootStore()
