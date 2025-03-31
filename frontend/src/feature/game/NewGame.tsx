import { Box, Button, Typography } from '@mui/material'
import { FormTextField } from 'component/FormTextField'
import { Formik, Form } from 'formik'
import { Game, gameValidation } from './gameValidation'
import { postNewGame } from './GameGateway'

export const NewGame = () => {
	return (
		<Formik
			{...gameValidation}
			onSubmit={(game: Game) => {
				postNewGame(game)
				console.log(game)
			}}
		>
			{() => (
				<Form
					style={{
						padding: 2 * 8,
						width: 600,
						marginInline: 'auto',
						display: 'flex',
						flexDirection: 'column',
						gap: 2 * 8,
						textAlign: 'center',
					}}
				>
					<Typography variant='h1' sx={{ fontSize: 32 }}>
						New Game
					</Typography>

					<FormTextField name='name' label='Name' />

					<FormTextField
						name='description'
						label='Description'
						multiline
						minRows={4}
					/>

					<Box>
						<Button type='submit'>Submit</Button>
					</Box>
				</Form>
			)}
		</Formik>
	)
}
