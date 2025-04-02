import { Box, Button, LinearProgress, Typography } from '@mui/material'
import { FormTextField } from 'components/FormTextField'
import { Formik, Form } from 'formik'
import { GameSchema, validationSchema } from './gameValidation'
import { useGames } from 'features/games/useGames'
import { useNavigate, useParams } from 'react-router-dom'

export const GameForm = () => {
	const { id } = useParams()
	const { game, isLoadingGame, createGame, updateGame } = useGames(id)
	const navigate = useNavigate()

	const handleSubmit = async (values: GameSchema, { setSubmitting }: any) => {
		try {
			if (game) {
				updateGame.mutate(
					{ ...values, id: game.id },
					{
						onSuccess: () => {
							navigate(`/games`)
						},
					}
				)
				return
			}

			createGame.mutate(
				{ ...values },
				{
					onSuccess: () => {
						navigate(`/games`)
					},
				}
			)
		} finally {
			setSubmitting(false)
		}
	}

	if (id && isLoadingGame) return <LinearProgress />

	const initialValues: GameSchema = {
		name: game?.name ?? '',
	}

	return (
		<Formik
			validationSchema={validationSchema}
			initialValues={initialValues}
			onSubmit={handleSubmit}
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

					{/* <FormTextField
						name='description'
						label='Description'
						multiline
						minRows={4}
					/> */}

					<Box>
						<Button type='submit'>Submit</Button>
					</Box>
				</Form>
			)}
		</Formik>
	)
}
