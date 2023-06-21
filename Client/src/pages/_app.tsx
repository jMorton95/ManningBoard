import { Provider } from 'react-redux';
import { LineStateContextProvider } from '../contexts/LineStateContext';
import { type ReactNode } from 'react';
import store from '@/redux/store/Store';
import { type AppProps } from 'next/app';
import '../styles/bootstrap.css';
import '../styles/index.css';
import '../styles/Utilities.css';
import Layout from '@/components/Layout';

export default function App({ Component, pageProps }: AppProps): ReactNode {
  return (
    <Provider store={store}>
      <LineStateContextProvider>
        <Layout>
          <Component {...pageProps} />
        </Layout>
      </LineStateContextProvider>
    </Provider>
  );
}
