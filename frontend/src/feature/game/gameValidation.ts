import * as Yup from 'yup'

export type Game = {
	name: string
	description: string
}

const validationSchema: Yup.ObjectSchema<Game> = Yup.object({
	name: Yup.string().required('Required'),
	description: Yup.string().required('Required'),
})

const initialValues: Yup.InferType<typeof validationSchema> = {
	name: '',
	description: '',
}

export const gameValidation = { validationSchema, initialValues }
