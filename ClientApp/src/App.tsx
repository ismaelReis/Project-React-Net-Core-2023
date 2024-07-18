import jsonServerProvider from 'ra-data-json-server';
import { Admin, ListGuesser, Resource } from 'react-admin';


const dataProvider = jsonServerProvider('api');

function App() {
    return (
        <Admin
            dataProvider={dataProvider}
        >
            <Resource
                name="cidadaos"
                list={ListGuesser}
                options={{ label: "Cidadãos" }}
                recordRepresentation="nome"
            />
            <Resource
                name="visitasDomiciliar"
                list={ListGuesser}
                options={{ label: "Visitas domiciliares" }}
            />
            <Resource
                name="funcionarios"
                list={ListGuesser}
                options={{ label: "Funcionários" }}
                recordRepresentation="nome"
            />
            <Resource
                name="estabelecimentos"
                list={ListGuesser}
                options={{ label: "Estabelecimentos" }}
                recordRepresentation="nome"
            />
            <Resource
                name="equipes"
                list={ListGuesser}
                options={{ label: "Equipes" }}
                recordRepresentation="nome"
            />
            <Resource
                name="cbos"
                recordRepresentation="nome"
            />
        </Admin>
    );
}

export default App;
