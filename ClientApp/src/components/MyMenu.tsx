// in src/MyMenu.js
import { Menu } from 'react-admin';
import SettingsIcon from '@mui/icons-material/Settings';

export const MyMenu = () => (
    <Menu>
        {/* <Menu.DashboardItem /> */}
        <Menu.ResourceItems />
        <Menu.Item to="/mapa" primaryText="Mapa" leftIcon={<SettingsIcon />}/>
    </Menu>
);