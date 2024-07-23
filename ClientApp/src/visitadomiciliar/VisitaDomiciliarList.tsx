import { Datagrid, DateField, DateInput, List, Loading, NumberField, Pagination, ReferenceField, TextField, useGetList, useListContext } from 'react-admin';
import Mapa from '../mapa/Mapa';


const filters = [
    <DateInput source='startDate' />,
    <DateInput source='endDate' />,

]

const AsideMap = () => {
    const { filterValues } = useListContext();

    const { data = [], isPending } = useGetList(
        'visitasDomiciliar',
        {
            pagination: { page: 0, perPage: 0 },
            sort: { field: 'data', order: 'DESC' },
            filter: { ...filterValues, latitude: "not null", longitude: "not null" }
        }
    );
    
    console.log(data)
    return !isPending ? <Mapa visitasDomiciliar={data}/> : <Loading />
}

export const VisitaDomiciliarList = () => (
    <List filters={filters}>
        <AsideMap />
        <Datagrid>
            <TextField source="id" />
            <ReferenceField source="funcionarioId" reference="funcionarios" />
            <ReferenceField source="cidadaoId" reference="cidadaos" />
            <ReferenceField source="estabelecimentoId" reference="estabelecimentos" />
            <ReferenceField source="equipeId" reference="equipes" />
            <DateField source="data" />
            <NumberField source="turno" />
            <ReferenceField source="cboId" reference="cbos" />
            <DateField source="microArea" />
            <TextField source="cns" />
            <TextField source="codigoDomicilio" />
            <DateField source="nascimento" />
        </Datagrid>
        <Pagination />
    </List>
);