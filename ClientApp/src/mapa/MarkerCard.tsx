import { InfoBox } from '@react-google-maps/api'
import { Box, Typography, Divider } from '@mui/material';
import { Button } from 'react-admin';
import { IVisitaDomiciliar } from '../interfaces/IVisitaDomiciliar';
import moment from 'moment';
import PersonIcon from '@mui/icons-material/Person';
import MedicalInformationIcon from '@mui/icons-material/MedicalInformation';
import ApartmentIcon from '@mui/icons-material/Apartment';
import { Link } from 'react-router-dom';

const MarkerCard = ({ visitaDomiciliar, setVisitaDomiciliar }: { visitaDomiciliar: IVisitaDomiciliar, setVisitaDomiciliar: Function }) => {
    return (
        <InfoBox
            position={
                new google.maps.LatLng(
                    visitaDomiciliar.latitude ?? 0,
                    visitaDomiciliar.longitude ?? 0,
                )
            }
            options={{
                closeBoxURL: '',
                enableEventPropagation: true,
            }}
        >
            <Box
                borderRadius="10px"
                boxShadow="0px 4px 4px 0px rgba(0, 0, 0, 0.05)"
                padding="9px 13px"
                width="100%"
                sx={{ backgroundColor: '#fff' }}
            >
                <Box display="flex" alignItems="center" justifyContent="space-between">
                    <Typography variant="body2" fontWeight="bold">
                        {moment(visitaDomiciliar.data).toDate().toLocaleDateString()}
                    </Typography>
                    <Button
                        size="small"
                        onClick={() => setVisitaDomiciliar(null)}
                        sx={{ padding: '4px' }}
                        label='Fechar'
                    />

                </Box>


                <Box display="flex" alignItems="start" justifyContent="space-between">
                    <Box>
                        <Typography fontSize="12px" variant="body2">
                            <PersonIcon fontSize='small' />    {visitaDomiciliar.cidadao && visitaDomiciliar.cidadao.nome}
                        </Typography>
                        <Divider />
                        <Typography fontSize="12px" variant="body2">
                            <MedicalInformationIcon fontSize='small' />    {visitaDomiciliar.funcionario && visitaDomiciliar.funcionario.nome}
                        </Typography>
                        <Divider />
                        <Typography fontSize="12px" variant="body2">
                            <ApartmentIcon fontSize='small' />    {visitaDomiciliar.estabelecimento && visitaDomiciliar.estabelecimento.nome}
                        </Typography>

                        <Button
                            size="small"
                            sx={{ padding: '4px' }}
                            label='Ver mais'
                            component={Link}
                            to={`${visitaDomiciliar.id}/show`}
                        />

                    </Box>
                </Box>
            </Box>
        </InfoBox>
    )
}

export default MarkerCard