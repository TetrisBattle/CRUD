import * as Yup from 'yup'

const validationSchema = Yup.object({
	name: Yup.string().required('Required'),
	description: Yup.string().required('Required'),
})

const initialValues: Yup.InferType<typeof validationSchema> = {
	name: '',
	description: '',
}

export const gameValidation = { validationSchema, initialValues }
