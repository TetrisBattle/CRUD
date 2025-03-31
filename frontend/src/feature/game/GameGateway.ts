import axios, { AxiosResponse } from 'axios'
import { Game } from './gameValidation'

type HelloResponse = string

const baseApiUrl = 'http://localhost:5000/api'

export async function callHelloApi(): Promise<HelloResponse> {
	try {
		const apiUrl = baseApiUrl + '/Game'
		const response: AxiosResponse<HelloResponse> = await axios.get(apiUrl)
		return response.data
	} catch (error) {
		console.error('Error calling API:', error)
		throw error // Re-throw or handle as needed
	}
}

export async function postNewGame(game: Game): Promise<HelloResponse> {
	try {
		const apiUrl = baseApiUrl + '/Game'
		const response: AxiosResponse<HelloResponse> = await axios.post(
			apiUrl,
			game
		)
		return response.data
	} catch (error) {
		console.error('Error calling API:', error)
		throw error // Re-throw or handle as needed
	}
}
