import { makeAutoObservable } from 'mobx'

export class GameStore {
	constructor() {
		makeAutoObservable(this)
	}
}
