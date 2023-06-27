//eslint-disable-next-line @typescript-eslint/no-var-requires
const path = require('path');

/**@type {import("eslint").Linter.Config} */
const config = {
  overrides: [
    {
      plugins: ['@typescript-eslint', 'prettier'],
      extends: ['plugin:@typescript-eslint/recommended', 'prettier'],
      parser: '@typescript-eslint/parser',
      files: ['*.ts', '*.tsx'],
    }
  ],
  parser: '@typescript-eslint/parser',
  plugins: ['@typescript-eslint'],
  extends: ['plugin:@typescript-eslint/recommended'],
  rules: {
    '@typescript-eslint/consistent-type-imports': [
      'warn',
      {
        prefer: 'type-imports',
        fixStyle: 'inline-type-imports'
      }
    ],
    '@typescript-eslint/no-unused-vars': ['warn', { argsIgnorePattern: '^_' }],
    'indent': 'off',
    '@typescript-eslint/indent': ['error', 2]
  }
};

module.exports = config;
