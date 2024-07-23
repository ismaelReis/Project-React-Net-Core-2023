import jsonServerProvider from 'ra-data-json-server';
import { Admin, CustomRoutes, ListGuesser, Resource, ShowGuesser } from 'react-admin';
import { IDomicilio } from './interfaces/IDomicilio';
import { Route } from "react-router-dom";
import Mapa from './mapa/Mapa';
import { MyLayout } from './components/MyLayout';
import { VisitaDomiciliarList } from './visitadomiciliar/VisitaDomiciliarList';

const dataProvider = jsonServerProvider('api');

function App() {
    return (
        <Admin
            dataProvider={dataProvider}
            layout={MyLayout}
        >
            <Resource
                name="cidadaos"
                list={ListGuesser}
                show={ShowGuesser}
                options={{ label: "Cidadãos" }}
                recordRepresentation="nome"
            />
            <Resource
                name="visitasDomiciliar"
                list={VisitaDomiciliarList}
                show={ShowGuesser}
                options={{ label: "Visitas domiciliares" }}
            />
            <Resource
                name="funcionarios"
                list={ListGuesser}
                show={ShowGuesser}
                options={{ label: "Funcionários" }}
                recordRepresentation="nome"
            />
            <Resource
                name="estabelecimentos"
                list={ListGuesser}
                show={ShowGuesser}
                options={{ label: "Estabelecimentos" }}
                recordRepresentation="nome"
            />
            <Resource
                name="equipes"
                list={ListGuesser}
                show={ShowGuesser}
                options={{ label: "Equipes" }}
                recordRepresentation="nome"
            />
            <Resource
                name="domicilios"
                list={ListGuesser}
                show={ShowGuesser}
                options={{ label: "Domicílios" }}
                recordRepresentation={(r: IDomicilio) => `${r.logradouro}, ${r.numero}, ${r.bairro}`}
            />
            <Resource
                name="cbos"
                recordRepresentation="nome"
            />
        </Admin>
    );
}

export default App;
