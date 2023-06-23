/**@type {import('next').NextConfig} */
const nextConfig = {
  reactStrictMode: true,
  swcMinify: true,
  eslint: {
    dirs: ['./app/*','./src/*']
  }
};

module.exports = nextConfig;
