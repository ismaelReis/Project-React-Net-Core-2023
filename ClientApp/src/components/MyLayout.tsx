// in src/MyLayout.js
import { Layout } from 'react-admin';
import { MyMenu } from './MyMenu';
import { ReactNode } from 'react';

export const MyLayout = ({ children }: {children: ReactNode }) => (
    <Layout menu={MyMenu}>
        {children}
    </Layout>
);