import * as Yup from 'yup'

export type Game = {
	id: string
	name: string
}

export type GameSchema = Omit<Game, 'id'>

export const validationSchema: Yup.ObjectSchema<GameSchema> = Yup.object({
	name: Yup.string().required('Required'),
})
