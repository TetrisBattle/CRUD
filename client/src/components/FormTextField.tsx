import { TextField, TextFieldProps } from '@mui/material'
import { useField } from 'formik'

type FormTextFieldProps = TextFieldProps & {
	name: string
}

export const FormTextField = ({ name, ...props }: FormTextFieldProps) => {
	const [field, meta] = useField(name)

	return (
		<TextField
			{...field}
			{...props}
			error={meta.touched && !!meta.error}
			helperText={meta.touched && meta.error}
		/>
	)
}
