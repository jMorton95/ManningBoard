module.exports = {
  overrides: [
    {
      plugins: ['@typescript-eslint', 'prettier'],
      extends: ['plugin:@typescript-eslint/recommended', 'prettier'],
      parser: '@typescript-eslint/parser',
      files: ['*.ts', '*.tsx'],
    }
  ],
  rules: {
    'printWidth': 160,
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

