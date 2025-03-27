import axios, { AxiosResponse } from 'axios'

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
